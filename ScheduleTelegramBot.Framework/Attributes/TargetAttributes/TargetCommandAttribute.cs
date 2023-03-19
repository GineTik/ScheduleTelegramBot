using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Attributes.TargetAttributes
{
    public class TargetCommandAttribute : TargetAttribute
    {
        public string TargetCommand { get; set; }

        public TargetCommandAttribute(string targetCommand)
        {
            if (String.IsNullOrEmpty(targetCommand))
                throw new ArgumentException(nameof(targetCommand));

            TargetCommand = targetCommand;
        }

        public override bool IsTarget(Update update)
        {
            string[] targetText = update.Message.Text.Split(' ');
            string command = targetText[0];

            return command == TargetCommand;
        }
    }
}
