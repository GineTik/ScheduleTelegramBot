using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Framework.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Configurators
{
    public class BotConfigurator
    {
        private readonly IServiceProvider _provider;

        private List<Type> _middlewaresTypes;
        private List<Middleware> _middlewares;
        private int _index;

        public BotConfigurator(IServiceProvider provider)
        {
            _provider = provider;
            _middlewares = new();
            _middlewaresTypes = new();
        }

        public BotConfigurator Use<TMiddleware>()
            where TMiddleware : Middleware
        {
            _middlewaresTypes.Add(typeof(TMiddleware));

            //var middleware = _provider.GetRequiredService<TMiddleware>();
            //_middlewares.Add(middleware);
            return this;
        }

        public void Run(string token)
        {
            var client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            Console.ReadKey();
        }

        private async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            _index = 0;

            if (_middlewaresTypes.Count == 0)
                return;

            var first = (Middleware)_provider.GetRequiredService(_middlewaresTypes[0]);
            await first.InvokeAsync(client, update, Next(client, update));
        }

        private async Task Error(ITelegramBotClient client, Exception exception, CancellationToken arg3)
        {
            Console.WriteLine($"{exception.Message}\n{exception.StackTrace}");
        }

        private Func<Task> Next(ITelegramBotClient client, Update update)
        {
            return async () =>
            {
                Middleware? next = null;

                if (_index < _middlewaresTypes.Count - 1)
                {
                    next = (Middleware)_provider.GetRequiredService(_middlewaresTypes[++_index]);
                    //next = _middlewares[++_index];
                    await next.InvokeAsync(client, update, Next(client, update));
                }
            };
        }
    }
}
