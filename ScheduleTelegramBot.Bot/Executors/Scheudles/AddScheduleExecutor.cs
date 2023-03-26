using ScheduleTelegramBot.BussinessLogic.Services.Interfaces;
using ScheduleTelegramBot.Framework.Attributes.BuildExecutorAttributes;
using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using ScheduleTelegramBot.Framework.Executors;

namespace ScheduleTelegramBot.Bot.Executors.Scheudles
{
    [TargetCommand("/add_schedule")]
    public class AddScheduleExecutor : Executor
    {
        private readonly IScheduleService _service;

        public AddScheduleExecutor(IScheduleService service)
        {
            _service = service;
        }

        public override async Task ExecuteAsync()
        {
            //await _service.AddScheduleAsync();
        }
    }
}
