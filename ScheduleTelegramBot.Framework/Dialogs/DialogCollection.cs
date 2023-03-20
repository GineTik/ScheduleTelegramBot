using ScheduleTelegramBot.Framework.Executors;

namespace ScheduleTelegramBot.Framework.Dialogs
{
    public class DialogCollection
    {
        private Dictionary<long, Dialog> _activeDialogs;
        private readonly ExecutorContextAccessor _accessor;

        public DialogCollection(ExecutorContextAccessor accessor)
        {
            _activeDialogs = new();
            _accessor = accessor;
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

        public Dialog? TryGet(long chatId)
        {
            _activeDialogs.TryGetValue(chatId, out Dialog? executor);
            
            if (executor != null)
                executor.ExecutorContext = _accessor.ExecutorContext;

            return executor;
        }
    }
}
