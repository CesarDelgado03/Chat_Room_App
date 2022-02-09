using ChatRoomApp.CommandBot.Infrastructure.Bot;
using ChatRoomApp.CommandBot.Infrastructure.CommandProcessing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChatRoomApp.CommandBot
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
