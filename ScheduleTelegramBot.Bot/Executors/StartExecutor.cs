using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors
{
    [TargetCommand("/start")]
    public class StartExecutor : Executor
    {
        private Dialog _dialog;

        public StartExecutor(DialogBuilder builder)
        {
            builder.AddStep<HiExecutor>();
            builder.AddStep<HowAgeExecutor>();
            builder.DialogEndedAction += DialogEnded;
     
            _dialog = builder.BuildDialog();
        }

        public override async Task ExecuteAsync()
        {
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"привіт, починаю роботу");
            await _dialog.ExecuteAsync();
        }

        public async Task DialogEnded()
        {
            var firstAnswer = _dialog.DialogContext.Get<HiExecutor>().Message.Text;
            var age = _dialog.DialogContext.Get<HowAgeExecutor>().Message.Text;

            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"{firstAnswer}, age: {age}");
        }
    }
}
