using ScheduleTelegramBot.Framework.Executors;
using ScheduleTelegramBot.Framework.Factories.Executors;
using ScheduleTelegramBot.Framework.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Middlewares.Implemetations
{
    public class TargetExecutorMiddleware : Middleware
    {
        private readonly IExecutorFactory _factory;
        private readonly ExecutorContextAccessor _accessor;

        public TargetExecutorMiddleware(IExecutorFactory factory, ExecutorContextAccessor accessor)
        {
            _factory = factory;
            _accessor = accessor;
        }

        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            var executorType = TargetHelper.GetExecutorType(update);

            if (executorType != null)
            {
                _accessor.ExecutorContext = new ExecutorContext
                {
                    Client = client,
                    Update = update,
                };
                var executor = _factory.Create(executorType);
                await executor.ExecuteAsync();
            }
            else
            {
                await next();
            }
        }
    }
}
