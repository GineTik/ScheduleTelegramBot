using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Attributes.BuildExecutorAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class BuildExecutorAttribute : Attribute
    {
        public abstract void Build(Update update, Executor executor);
    }
}
