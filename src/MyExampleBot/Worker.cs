using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyExampleBot.Bot;
using Telegram.Bot.Framework.Abstractions;

namespace MyExampleBot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBotManager<MyBot> botManager;

        public Worker(ILogger<Worker> logger, IBotManager<MyBot> botManager)
        {
            this.botManager = botManager;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await botManager.GetAndHandleNewUpdatesAsync();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
