using ScheduleTelegramBot.Framework.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Bot.Middlewares
{
    public class Test2Middleware : Middleware
    {
        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            if (update.Message.Text == "привіт")
                await client.SendTextMessageAsync(update.Message.Chat.Id, "і тобі привіт");
            else
                await next();
        }
    }
}
