using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Middlewares;
using System.Reflection;

namespace ScheduleTelegramBot.Framework.Configurators
{
    public class BotConfiguratorBuilder
    {
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }

        public BotConfiguratorBuilder()
        {
            Services = new ServiceCollection();
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Assembly.GetCallingAssembly().Location, "../../../../")) // finds the way to the input project
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public BotConfigurator Build()
        {
            AddMiddlewares();
            Services.AddTransient(_ => Configuration);
            return new BotConfigurator(Services.BuildServiceProvider());
        }

        private void AddMiddlewares()
        {
            var types = Assembly.GetCallingAssembly().GetTypes()
                .Concat(Assembly.GetExecutingAssembly().GetTypes())
                .Where(t => t.BaseType == typeof(Middleware));

            foreach (var type in types)
                Services.AddTransient(type);
        }
    }
}
