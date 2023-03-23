using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegramBot.Framework.Factories.Buttons
{
    public interface IButtonFactory
    {
        public InlineKeyboardButton Create(string text);
        public InlineKeyboardButton Create<TExecutor>(string text)
            where TExecutor : Executor;
    }
}
