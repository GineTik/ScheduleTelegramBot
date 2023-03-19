using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Executors;
using ScheduleTelegramBot.Framework.Factories.Executors;
using System.Reflection;

namespace ScheduleTelegramBot.Framework.Extensions.ServicesExtensions
{
    public static class ExecutorServicesExtensions
    {
        public static void AddExecutors(this ServiceCollection services)
        {
            var types = Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(Executor));

            foreach (var type in types)
                services.AddTransient(type);

            services.AddTransient<IExecutorFactory, ExecutorFactory>();
        }
    }
}
