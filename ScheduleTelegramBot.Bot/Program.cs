using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Data.EF;
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
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            var middleware = builder.Build();
            middleware.Use<ExecutorContextAccessorMiddleware>();
            middleware.Use<TargetExecutorMiddleware>();
            middleware.Use<DialogMiddleware>();

            middleware.Run(ConfigurationManager.AppSettings.Get("TelegramBotToken"));
        }
    }
}