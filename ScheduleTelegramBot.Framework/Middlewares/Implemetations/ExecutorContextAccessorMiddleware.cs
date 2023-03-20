using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Middlewares.Implemetations
{
    public class ExecutorContextAccessorMiddleware : Middleware
    {
        private readonly ExecutorContextAccessor _accessor;

        public ExecutorContextAccessorMiddleware(ExecutorContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            _accessor.ExecutorContext = new()
            {
                Client = client,
                Update = update,
            };
            await next();
        }
    }
}
