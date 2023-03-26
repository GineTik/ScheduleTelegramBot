using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors.Scheudles.AddSchedule.DilaogSteps
{
    public class GetScheduleName : Executor
    {
        public override async Task ExecuteAsync()
        {
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, "Введіть назву розкладу");
        }
    }
}
