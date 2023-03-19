using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Middlewares
{
    public abstract class Middleware
    {
        public abstract Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next);
    }
}
