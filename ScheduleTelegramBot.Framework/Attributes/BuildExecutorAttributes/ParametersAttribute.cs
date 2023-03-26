using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Attributes.BuildExecutorAttributes
{
    public class ParametersAttribute : BuildExecutorAttribute
    {
        public string[] ParametersNames { get; set; }

        public ParametersAttribute(string parametersNames)
        {
            ParametersNames = parametersNames.Split(",");
        }

        public override void Build(Update update, Executor executor)
        {
            var parameters = update.Message?.Text?.Split(" ");

            for (int i = 0; i < ParametersNames.Length; i++)
                executor.Parameters.Add(
                    ParametersNames[i], 
                    parameters?.ElementAtOrDefault(i + 1) ?? "");
        }
    }
}
