using ScheduleTelegramBot.Framework.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Bot.Middlewares
{
    public class Test1Middleware : Middleware
    {
        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            Console.WriteLine("123");

            await next();
        }
    }
}
