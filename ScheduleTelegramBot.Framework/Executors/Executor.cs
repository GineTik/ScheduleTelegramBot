namespace ScheduleTelegramBot.Framework.Executors
{
    public abstract class Executor
    {
        public ExecutorContext ExecutorContext { get; set; }
        public Dictionary<string, string?> Parameters { get; set; } = new Dictionary<string, string?>();
        public abstract Task ExecuteAsync();
    }
}
