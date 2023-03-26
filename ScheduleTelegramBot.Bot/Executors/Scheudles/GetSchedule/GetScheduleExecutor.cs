using ScheduleTelegramBot.BussinessLogic.Services.Interfaces;
using ScheduleTelegramBot.Framework.Attributes.BuildExecutorAttributes;
using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using ScheduleTelegramBot.Framework.Buttons;
using ScheduleTelegramBot.Framework.Executors;
using ScheduleTelegramBot.Framework.Factories.Buttons;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors.Scheudles.GetSchedule
{
    [TargetCommand("/get_schedule")]
    [Parameters("id")]
    public class GetScheduleExecutor : Executor
    {
        private readonly IScheduleService _service;
        private readonly KeyboardBuilder _builder;
        private readonly IButtonFactory _factory;

        public GetScheduleExecutor(IScheduleService service, KeyboardBuilder builder, IButtonFactory factory)
        {
            _service = service;
            _builder = builder;
            _factory = factory;
        }

        public override async Task ExecuteAsync()
        {
            var id = Parameters["id"];

            if (id == null)
            {
                await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"Ви забули вказати розклад");
                return;
            }

            if (Guid.TryParse(id, out var guid) == false)
            {
                await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"Некоректний ітендифікатор розкладу");
                return;
            }

            var schedule = await _service.GetScheduleAsync(guid);

            if (schedule == null)
            {
                await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"Такого розкладу не існує");
                return;
            }

            foreach (var week in schedule.Weeks)
                _builder.AddColumn(_factory.Create(week.Name));

            var keyboard = _builder.Build();
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"{schedule.Name}", replyMarkup: keyboard);
        }
    }
}
