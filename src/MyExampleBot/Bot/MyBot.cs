using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Telegram.Bot.Framework;
using Telegram.Bot.Types;

namespace MyExampleBot.Bot
{
    public class MyBot : BotBase<MyBot>
    {
        public MyBot(IOptions<BotOptions<MyBot>> botOptions) : base(botOptions)
        {
        }

        public override Task HandleFaultedUpdate(Update update, Exception e) => Task.CompletedTask;

        public override Task HandleUnknownUpdate(Update update) => Task.CompletedTask;
    }
}