using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using GodotDiscordBot.Modules;
using GodotDiscordBot.Services;
using GodotDiscordBot.Services.Config;
using Microsoft.Extensions.DependencyInjection;

namespace GodotDiscordBot
{
    internal static class Program
    {
        public static Task Main()
            => StartBot();

        private static async Task StartBot()
        {
            await BuildServiceProvider().GetRequiredService<StartupService>().StartAsync();
            await Task.Delay(-1);
        }

        private static IServiceProvider BuildServiceProvider() => new ServiceCollection()
            .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 1000
            }))

            .AddSingleton(new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose,
                DefaultRunMode = RunMode.Async
            }))
            
            .AddSingleton<LoggingService>()
            .AddSingleton<Random>()
            .AddSingleton<SimpleLinksModule>()
            .AddSingleton<SimpleBotCommandsModule>()
            .AddSingleton<CommandHandler>()
            .AddSingleton<BotConfigurationService>()
            .AddSingleton<ShowcaseSupportService>()
            .AddSingleton<MemeService>()
            .AddSingleton<StartupService>()
            .BuildServiceProvider();
    }
}