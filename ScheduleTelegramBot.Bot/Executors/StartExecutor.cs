using ScheduleTelegramBot.Framework.Attributes.TargetAttributes;
using ScheduleTelegramBot.Framework.Buttons;
using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Executors;
using ScheduleTelegramBot.Framework.Factories.Buttons;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegramBot.Bot.Executors
{
    [TargetCommand("/start")]
    public class StartExecutor : Executor
    {
        private Dialog _dialog;
        private InlineKeyboardMarkup _keyboard;

        public StartExecutor(DialogBuilder builder, KeyboardBuilder keyboardBuilder, IButtonFactory buttonFactory)
        {
            builder.AddStep<HiExecutor>();
            builder.AddStep<HowAgeExecutor>();
            builder.DialogEndedAction += DialogEnded;
     
            _dialog = builder.BuildDialog();

            _keyboard = keyboardBuilder
                .AddColumn(buttonFactory.Create<HiExecutor>("Привітатися"))
                .Build();
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

            await ExecutorContext.Client.SendTextMessageAsync(ExecutorContext.ChatId, $"{firstAnswer}, age: {age}", replyMarkup: _keyboard);
        }
    }
}
