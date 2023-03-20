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

            var middleware = builder.Build();
            middleware.Use<ExecutorContextAccessorMiddleware>();
            middleware.Use<TargetExecutorMiddleware>();
            middleware.Use<DialogMiddleware>();

            middleware.Run("6297259263:AAGFl9aJtYf0f4m2tarQwlZBtwcJLTZTHdM");
        }
    }
}