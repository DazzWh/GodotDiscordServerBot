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
        private readonly AcceptRulesService _acceptRulesService;

        public StartupService(
            DiscordSocketClient discord,
            LoggingService logging,
            BotConfigurationService configService,
            CommandHandler commandHandler,
            MemeService memeService,
            AcceptRulesService acceptRulesService,
            ShowcaseSupportService showcaseSupportService)
        {
            _client = discord;
            _logging = logging;
            _configService = configService;
            _commandHandler = commandHandler;
            _memeService = memeService;
            _showcaseSupportService = showcaseSupportService;
            _acceptRulesService = acceptRulesService;
        }

        public async Task StartAsync()
        {
            _logging.Initialize();
            _configService.Initialize();
            _memeService.Initialize();
            _showcaseSupportService.Initialize();
            _acceptRulesService.Initialize();

            await _client.LoginAsync(TokenType.Bot,
            Environment.GetEnvironmentVariable("DiscordTokenGodot") ?? _configService.Current.DiscordToken);
            await _client.StartAsync();

            await _commandHandler.Initialize();
        }
    }
}