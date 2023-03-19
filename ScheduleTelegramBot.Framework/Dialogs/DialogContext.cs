using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Dialogs
{
    public class DialogContext
    {
        public Dictionary<Type, Update> Updates { get; set; }

        public DialogContext()
        {
            Updates = new();
        }

        public Update Get<T>()
        {
            return Updates[typeof(T)];
        }
    }
}
