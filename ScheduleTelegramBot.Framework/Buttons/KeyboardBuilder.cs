using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegramBot.Framework.Buttons
{
    public class KeyboardBuilder
    {
        private readonly List<InlineKeyboardButton[]> _columns;

        public KeyboardBuilder()
        {
            _columns = new();
        }

        public KeyboardBuilder AddColumn(params InlineKeyboardButton[] buttons)
        {
            _columns.Add(buttons);
            return this;
        }

        public InlineKeyboardMarkup Build()
        {
            return new InlineKeyboardMarkup(_columns);
        }
    }
}
