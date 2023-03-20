using ScheduleTelegramBot.Framework.Executors;

namespace ScheduleTelegramBot.Framework.Factories.Executors
{
    public interface IExecutorFactory
    {
        T Create<T>()
            where T : Executor;
        Executor Create(Type type);
    }
}
