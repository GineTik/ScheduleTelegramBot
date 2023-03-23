using ScheduleTelegramBot.Framework.Factories.Executors;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Middlewares.Implemetations
{
    public class ButtonMiddleware : Middleware
    {
        private readonly IExecutorFactory _factory;

        public ButtonMiddleware(IExecutorFactory factory)
        {
            _factory = factory;
        }

        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            string? typeName = update.CallbackQuery?.Data;
            var type = Assembly.GetEntryAssembly().GetTypes().
                FirstOrDefault(x => x.Name == typeName);
                 
            if (type == null)
            {
                await next();
                return;
            }

            var executor = _factory.Create(type);
            await executor.ExecuteAsync();
        }
    }
}
