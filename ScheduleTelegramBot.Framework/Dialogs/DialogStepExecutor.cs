using ScheduleTelegramBot.Framework.Executors;

namespace ScheduleTelegramBot.Framework.Dialogs
{
    public abstract class DialogStepExecutor : Executor
    {
        public DialogContext DialogContext { get; set; }
    }
}
