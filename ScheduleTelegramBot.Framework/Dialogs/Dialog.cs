using ScheduleTelegramBot.Framework.Executors;
using ScheduleTelegramBot.Framework.Factories.Executors;

namespace ScheduleTelegramBot.Framework.Dialogs
{
    public class Dialog : Executor
    {
        public event Action<long> DialogEndedAction;

        public List<Type> ExecutorsTypes { get; set; }
        public DialogContext DialogContext { get; }

        public Type? PreviosType => ExecutorsTypes.ElementAtOrDefault(_currentIndex - 1);
        public Type CurrentType => ExecutorsTypes[_currentIndex];

        public bool DialogIsEnded => _currentIndex >= ExecutorsTypes.Count;

        private int _currentIndex;
        private readonly IExecutorFactory _factory;

        public Dialog(IExecutorFactory factory)
        {
            ExecutorsTypes = new();
            DialogContext = new();
            _currentIndex = 0;
            _factory = factory;
        }

        public override async Task ExecuteAsync()
        {
            if (PreviosType != null)
                DialogContext.Updates.Add(PreviosType, ExecutorContext.Update);

            if (DialogIsEnded == true)
            {
                DialogEndedAction?.Invoke(ExecutorContext.ChatId);
                return;
            }

            await ExecuteCurrentStepAsync();
            _currentIndex++;
        }

        private async Task ExecuteCurrentStepAsync()
        {
            var executor = _factory.Create(ExecutorsTypes[_currentIndex]);

            if (executor is DialogStepExecutor step)
                step.DialogContext = DialogContext;

            await executor.ExecuteAsync();
        }
    }
}
