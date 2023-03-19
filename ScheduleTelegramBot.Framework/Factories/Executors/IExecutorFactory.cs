using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Factories.Executors
{
    public interface IExecutorFactory
    {
        Executor Create(Type type, ITelegramBotClient client, Update update);
        Executor Create(Type type, ExecutorContext context);
    }
}
