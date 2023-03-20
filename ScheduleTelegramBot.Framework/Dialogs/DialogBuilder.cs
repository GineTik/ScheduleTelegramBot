using ScheduleTelegramBot.Framework.Executors;
using ScheduleTelegramBot.Framework.Factories.Executors;

namespace ScheduleTelegramBot.Framework.Dialogs
{
    public class DialogBuilder
    {
        public Func<Task> DialogEndedAction;

        private readonly List<Type> _stepsTypes;
        private readonly IExecutorFactory _factory;
        private readonly DialogCollection _dialogCollection;
        private readonly ExecutorContextAccessor _accessor;

        public DialogBuilder(IExecutorFactory factory, DialogCollection dialogCollection, ExecutorContextAccessor accessor)
        {
            _stepsTypes = new();
            _factory = factory;
            _dialogCollection = dialogCollection;
            _accessor = accessor;
        }

        public void AddStep<TStep>()
            where TStep : Executor
        {
            _stepsTypes.Add(typeof(TStep));
        }

        public Dialog BuildDialog()
        {
            var dialog = _factory.Create<Dialog>();
            
            dialog.ExecutorsTypes = _stepsTypes;
            dialog.DialogEndedAction += _dialogCollection.Remove;
            dialog.DialogEndedAction += _ => DialogEndedAction?.Invoke();

            _dialogCollection.Add(_accessor.ExecutorContext.ChatId, dialog);
            return dialog;
        }
    }
}
