using Microsoft.Extensions.Configuration;
using ScheduleTelegramBot.Bot.Extensions.ServicesExtensions;
using ScheduleTelegramBot.Framework.Configurators;
using ScheduleTelegramBot.Framework.Extensions.ServicesExtensions;
using ScheduleTelegramBot.Framework.Middlewares.Implemetations;

namespace ScheduleTelegramBot.Bot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new BotConfiguratorBuilder();
            builder.Services.AddExecutors();
            builder.Services.AddDialogs();
            builder.Services.AddButtons();
            builder.Services.AddDbContextAndRepositories(
                builder.Configuration.GetConnectionString("DefaultConnection"));

            var middleware = builder.Build();
            middleware.Use<ExecutorContextAccessorMiddleware>();
            middleware.Use<TargetExecutorMiddleware>();
            middleware.Use<DialogMiddleware>();
            middleware.Use<ButtonMiddleware>();

            middleware.Run(builder.Configuration.GetRequiredSection("Telegram:Token").Value);
        }
    }
}