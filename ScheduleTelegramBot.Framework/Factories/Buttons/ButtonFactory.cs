using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegramBot.Framework.Factories.Buttons
{
    public class ButtonFactory : IButtonFactory
    {
        public InlineKeyboardButton Create(string text)
        {
            return new InlineKeyboardButton(text);
        }

        public InlineKeyboardButton Create<TExecutor>(string text)
            where TExecutor : Executor
        {
            var callbackData = typeof(TExecutor).Name;
            return InlineKeyboardButton.WithCallbackData(text, callbackData);
        }
    }
}
