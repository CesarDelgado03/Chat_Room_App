using ChatRoomApp.WorkerBot.Infrastructure.Bot;
using ChatRoomApp.WorkerBot.Infrastructure.CommandProcessing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomApp.WorkerBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ICommandProcessor, CommandProcessorService>();
                    services.AddSingleton<IRabbitMQService, BotCommunicationService>();
                    services.AddHostedService<Worker>();
                });
    }
}
