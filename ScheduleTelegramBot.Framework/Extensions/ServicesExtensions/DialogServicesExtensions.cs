using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Helpers;

namespace ScheduleTelegramBot.Framework.Extensions.ServicesExtensions
{
    public static class DialogServicesExtensions
    {
        public static void AddDialogs(this ServiceCollection services)
        {
            var types = DialogHelper.GetDialogStepExecutors();

            foreach (var type in types)
                services.AddTransient(type);

            services.AddSingleton<DialogCollection>();
            services.AddTransient<DialogBuilder>();
            services.AddTransient<Dialog>();
        }
    }
}
