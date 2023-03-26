using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Attributes.BuildExecutorAttributes;
using ScheduleTelegramBot.Framework.Executors;
using System.Reflection;

namespace ScheduleTelegramBot.Framework.Factories.Executors
{
    public class ExecutorFactory : IExecutorFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ExecutorContext _executorContext;

        public ExecutorFactory(IServiceProvider provider, ExecutorContextAccessor accessor)
        {
            _provider = provider;
            _executorContext = accessor.ExecutorContext;
        }

        public Executor Create(Type type)
        {
            var executor = (Executor)_provider.GetRequiredService(type);
            executor.ExecutorContext = _executorContext;

            foreach (var attribute in executor.GetType().GetCustomAttributes<BuildExecutorAttribute>())
                attribute.Build(_executorContext.Update, executor);

            return executor;
        }

        public T Create<T>() where T : Executor
        {
            return (T)Create(typeof(T));
        }
    }
}
