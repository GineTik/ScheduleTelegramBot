using ScheduleTelegramBot.Bot.Executors.Scheudles.AddSchedule.DilaogSteps;
using ScheduleTelegramBot.BussinessLogic.Services.Interfaces;
using ScheduleTelegramBot.Core.DTOs.ScheduleDTOs;
using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors.Scheudles.AddSchedule
{
    [TargetCommand("/add_schedule")]
    public class AddScheduleExecutor : Executor
    {
        private readonly IScheduleService _service;
        private readonly Dialog _dialog;

        public AddScheduleExecutor(IScheduleService service, DialogBuilder builder)
        {
            _service = service;

            _dialog = builder
                .AddStep<GetScheduleName>()
                .AddDialogEndedCallback(DialogEnded)
                .BuildDialog();
        }

        public override async Task ExecuteAsync()
        {
            await _dialog.ExecuteAsync();
        }

        public async Task DialogEnded()
        {
            var name = _dialog.DialogContext.Get<GetScheduleName>()?.Message?.Text;
            var result = await _service.AddScheduleAsync(new AddScheduleDTO()
            {
                Name = name
            });
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"ітендифікатор: {result}");
        }
    }
}
