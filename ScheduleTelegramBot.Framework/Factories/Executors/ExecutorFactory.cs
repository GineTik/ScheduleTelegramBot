using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Executors;

namespace ScheduleTelegramBot.Framework.Factories.Executors
{
    public class ExecutorFactory : IExecutorFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ExecutorContextAccessor _accessor;

        public ExecutorFactory(IServiceProvider provider, ExecutorContextAccessor accessor)
        {
            _provider = provider;
            _accessor = accessor;
        }

        public Executor Create(Type type)
        {
            var executor = (Executor)_provider.GetRequiredService(type);
            executor.ExecutorContext = _accessor.ExecutorContext;
            return executor;
        }

        public T Create<T>() where T : Executor
        {
            return (T)Create(typeof(T));
        }
    }
}
