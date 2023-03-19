using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Factories.Executors
{
    public class ExecutorFactory : IExecutorFactory
    {
        private readonly IServiceProvider _provider;

        public ExecutorFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Executor Create(Type type, ITelegramBotClient client, Update udpate)
        {
            var executor = (Executor)_provider.GetRequiredService(type);
            executor.ExecutorContext = new()
            {
                Client = client,
                Update = udpate
            };
            return executor;
        }

        public Executor Create(Type type, ExecutorContext context)
        {
            return Create(type, context.Client, context.Update);
        }
    }
}
