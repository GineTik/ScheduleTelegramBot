using ScheduleTelegramBot.Framework.Factories.Executors;
using ScheduleTelegramBot.Framework.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Middlewares.Implemetations
{
    public class TargetExecutorMiddleware : Middleware
    {
        private readonly IExecutorFactory _factory;

        public TargetExecutorMiddleware(IExecutorFactory factory)
        {
            _factory = factory;
        }

        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            var executorType = TargetHelper.GetExecutorType(update);

            if (executorType != null)
            {
                var executor = _factory.Create(executorType, client, update);
                await executor.ExecuteAsync();
            }
            else
            {
                await next();
            }
        }
    }
}
