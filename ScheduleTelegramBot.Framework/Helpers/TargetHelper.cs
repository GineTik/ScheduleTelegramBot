using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using System.Reflection;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Helpers
{
    public static class TargetHelper
    {
        public static IEnumerable<Type> GetTargersTypes()
        {
            return Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<TargetAttribute>() != null);
        }

        public static Type? GetExecutorType(Update update)
        {
            return Assembly.GetEntryAssembly().GetTypes()
                .FirstOrDefault(t => t.GetCustomAttributes<TargetAttribute>().Any(a => a.IsTarget(update)));
        }
    }
}
