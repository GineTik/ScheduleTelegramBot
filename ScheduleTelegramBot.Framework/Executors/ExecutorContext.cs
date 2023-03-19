using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Executors
{
    public class ExecutorContext
    {
        public ITelegramBotClient Client { get; set; }
        public Update Update { get; set; }
        public long ChatId => Update.Message?.Chat?.Id ?? Update.CallbackQuery.Message.Chat.Id;
    }
}
