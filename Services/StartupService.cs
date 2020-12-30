using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using GodotDiscordBot.Services.Config;

namespace GodotDiscordBot.Services
{
    public class StartupService
    {
        private readonly DiscordSocketClient _client;
        private readonly LoggingService _logging;
        private readonly BotConfigurationService _configService;
        private readonly CommandHandler _commandHandler;
        private readonly MemeService _memeService;
        private readonly ShowcaseSupportService _showcaseSupportService;

        public StartupService(
            DiscordSocketClient discord,
            LoggingService logging,
            BotConfigurationService configService,
            CommandHandler commandHandler,
            MemeService memeService,
            ShowcaseSupportService showcaseSupportService)
        {
            _client = discord;
            _logging = logging;
            _configService = configService;
            _commandHandler = commandHandler;
            _memeService = memeService;
            _showcaseSupportService = showcaseSupportService;
        }

        public async Task StartAsync()
        {
            _logging.Initialize();
            _configService.Initialize();
            _memeService.Initialize();
            _showcaseSupportService.Initialize();

            await _client.LoginAsync(TokenType.Bot,
            Environment.GetEnvironmentVariable("DiscordTokenGodot") ?? _configService.GetDiscordToken());
            await _client.StartAsync();

            await _commandHandler.Initialize();
        }
    }
}