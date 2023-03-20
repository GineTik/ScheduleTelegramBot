namespace ScheduleTelegramBot.Framework.Executors
{
    public class ExecutorContextAccessor
    {
        private static AsyncLocal<ExecutorContext> _context;

        public ExecutorContextAccessor()
        {
            _context = new();
        }

        public ExecutorContext ExecutorContext
        {
            get { return _context.Value; }
            set { _context.Value = value; }
        }
    }
}
