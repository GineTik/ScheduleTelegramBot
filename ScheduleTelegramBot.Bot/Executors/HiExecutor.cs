using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors
{
    public class HiExecutor : DialogStepExecutor
    {
        public override async Task ExecuteAsync()
        {
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, "Привіт");
        }
    }
}
