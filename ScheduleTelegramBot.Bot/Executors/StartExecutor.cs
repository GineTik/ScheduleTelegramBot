using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;

namespace ScheduleTelegramBot.Bot.Executors
{
    [TargetCommand("/start")]
    public class StartExecutor : Executor
    {
        private readonly DialogBuilder _builder;
        private Dialog _dialog;

        public StartExecutor(DialogBuilder builder)
        {
            builder.AddStep<HiExecutor>();
            builder.AddStep<HowAgeExecutor>();
            builder.DialogEndedAction += DialogEnded;
            _builder = builder;
        }

        public override async Task ExecuteAsync()
        {
            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"привіт, починаю роботу");

            _dialog = _builder.BuildDialog(ExecutorContext);
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
