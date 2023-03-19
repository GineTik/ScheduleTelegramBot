using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors
{
    public class HowAgeExecutor : Executor
    {
        public override async Task ExecuteAsync()
        {
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, "Скільки тобі років?");
        }
    }
}
