using ScheduleTelegramBot.Bot.Extensions.ServicesExtensions;
using ScheduleTelegramBot.Framework.Configurators;
using ScheduleTelegramBot.Framework.Extensions.ServicesExtensions;
using ScheduleTelegramBot.Framework.Middlewares.Implemetations;
using System.Configuration;

namespace ScheduleTelegramBot.Bot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new BotConfiguratorBuilder();
            builder.Services.AddExecutors();
            builder.Services.AddDialogs();
            builder.Services.AddDbContextAndRepositories();

            var middleware = builder.Build();
            middleware.Use<ExecutorContextAccessorMiddleware>();
            middleware.Use<TargetExecutorMiddleware>();
            middleware.Use<DialogMiddleware>();

            middleware.Run(ConfigurationManager.AppSettings.Get("TelegramBotToken"));
        }
    }
}