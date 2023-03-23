using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Buttons;
using ScheduleTelegramBot.Framework.Factories.Buttons;

namespace ScheduleTelegramBot.Framework.Extensions.ServicesExtensions
{
    public static class ButtonServicesExtensions
    {
        public static void AddButtons(this IServiceCollection services)
        {
            services.AddSingleton<KeyboardBuilder>();
            services.AddSingleton<IButtonFactory, ButtonFactory>();
        }
    }
}
