using ScheduleTelegramBot.Framework.Dialogs;
using System.Reflection;

namespace ScheduleTelegramBot.Framework.Helpers
{
    public static class DialogHelper
    {
        public static IEnumerable<Type> GetDialogStepExecutors()
        {
            return Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(DialogStepExecutor));
        }
    }
}
