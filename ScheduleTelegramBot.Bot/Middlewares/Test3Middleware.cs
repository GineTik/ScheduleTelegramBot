using ScheduleTelegramBot.Framework.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Bot.Middlewares
{
    public class Test3Middleware : Middleware
    {
        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Test3Middleware done");
            await next();
        }
    }
}
