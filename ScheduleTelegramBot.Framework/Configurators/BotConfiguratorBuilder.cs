using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Middlewares;
using System.Reflection;

namespace ScheduleTelegramBot.Framework.Configurators
{
    public class BotConfiguratorBuilder
    {
        public IServiceCollection Services { get; }

        public BotConfiguratorBuilder()
        {
            Services = new ServiceCollection();
        }

        public BotConfigurator Build()
        {
            AddMiddlewares();
            return new BotConfigurator(Services.BuildServiceProvider());
        }

        private void AddMiddlewares()
        {
            var types = Assembly.GetEntryAssembly().GetTypes()
                .Concat(Assembly.GetExecutingAssembly().GetTypes())
                .Where(t => t.BaseType == typeof(Middleware));

            foreach (var type in types)
                Services.AddTransient(type);
        }
    }
}
