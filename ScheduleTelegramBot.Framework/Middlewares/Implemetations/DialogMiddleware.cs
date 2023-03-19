﻿using ScheduleTelegramBot.Framework.Dialogs;
using ScheduleTelegramBot.Framework.Executors;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Framework.Middlewares.Implemetations
{
    public class DialogMiddleware : Middleware
    {
        private readonly DialogCollection _dialogs;

        public DialogMiddleware(DialogCollection dialogs)
        {
            _dialogs = dialogs;
        }

        public override async Task InvokeAsync(ITelegramBotClient client, Update update, Func<Task> next)
        {
            var executor = _dialogs.TryGet(
                update.Message?.Chat?.Id ?? update.CallbackQuery.Message.Chat.Id, 
                new ExecutorContext { Client = client, Update = update });

            if (executor != null)
                await executor.ExecuteAsync();
            else
                await next();
        }
    }
}
