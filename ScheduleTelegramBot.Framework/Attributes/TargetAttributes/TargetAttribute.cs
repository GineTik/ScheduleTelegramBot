using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Attributes.TargetAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class TargetAttribute : Attribute
    {
        public abstract bool IsTarget(Update update);
    }
}
