using ScheduleTelegramBot.Framework.Executors;

namespace ScheduleTelegramBot.Framework.Dialogs
{
    public class DialogCollection
    {
        private Dictionary<long, Executor> _activeDialogs;

        public DialogCollection()
        {
            _activeDialogs = new();
        }

        public void Add(long chatId, Dialog executor)
        {
            if (_activeDialogs.ContainsKey(chatId))
                _activeDialogs.Remove(chatId);

            executor.DialogEndedAction += (id) => _activeDialogs.Remove(id);
            _activeDialogs.Add(chatId, executor);
        }

        public void Remove(long chatId)
        {
            _activeDialogs.Remove(chatId);
        }

        public Executor? TryGet(long chatId, ExecutorContext newContext)
        {
            _activeDialogs.TryGetValue(chatId, out Executor? executor);
            
            if (executor != null)
                executor.ExecutorContext = newContext;
            // TODO: створювати новий екземпляр діалогу, а інформацію про діалог можна хранити в спеціальному класі (де буде індекс та тип наприклад)
            return executor;
        }
    }
}
