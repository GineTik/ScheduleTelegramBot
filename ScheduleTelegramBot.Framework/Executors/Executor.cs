namespace ScheduleTelegramBot.Framework.Executors
{
    public abstract class Executor
    {
        public ExecutorContext ExecutorContext { get; set; }
        public abstract Task ExecuteAsync();
    }
}
