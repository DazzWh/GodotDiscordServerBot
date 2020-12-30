using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using GodotDiscordBot.Services.Config;

namespace GodotDiscordBot.Services
{
    /// <summary>
    /// Adds an initial supportive reaction emoji to messages in #Showcase
    /// </summary>
    public class ShowcaseSupportService
    {
        private readonly DiscordSocketClient _client;
        private readonly BotConfigurationService _config;

        public ShowcaseSupportService(
                DiscordSocketClient client,
                BotConfigurationService config)
        {
            _client = client;
            _config = config;
        }

        public void Initialize()
        {
            _client.MessageReceived += HandleMessageReceived;
        }

        private async Task HandleMessageReceived(SocketMessage message)
        {
            if (message.Channel.Id.Equals(_config.GetShowcaseId()) &&
                Emote.TryParse($"<{_config.GetShowcaseEmote()}>", out var emote))
            {
                await message.AddReactionAsync(emote);
            }
        }
    }
}