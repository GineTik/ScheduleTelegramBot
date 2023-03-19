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

        public DialogBuilder(IExecutorFactory factory, DialogCollection dialogCollection)
        {
            _stepsTypes = new();
            _factory = factory;
            _dialogCollection = dialogCollection;
        }

        public void AddStep<TStep>()
            where TStep : Executor
        {
            _stepsTypes.Add(typeof(TStep));
        }

        public Dialog BuildDialog(ExecutorContext context)
        {
            var dialog = (Dialog)_factory.Create(typeof(Dialog), context);
            
            dialog.ExecutorsTypes = _stepsTypes;
            dialog.DialogEndedAction += _dialogCollection.Remove;
            dialog.DialogEndedAction += _ => DialogEndedAction?.Invoke();

            _dialogCollection.Add(context.ChatId, dialog);
            return dialog;
        }
    }
}
