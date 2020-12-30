using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using GodotDiscordBot.Services.Config;

namespace GodotDiscordBot.Services
{
    /// <summary>
    /// Gives a user the Godot role when they react to the rules message with a specific emote
    /// </summary>
    public class AcceptRulesService
    {
        private readonly DiscordSocketClient _client;
        private readonly BotConfigurationService _config;

        public AcceptRulesService(
            DiscordSocketClient client,
            BotConfigurationService config)
        {
            _client = client;
            _config = config;
        }

        public void Initialize()
        {
            _client.ReactionAdded += HandleRulesReaction;
        }

        private async Task HandleRulesReaction(
            Cacheable<IUserMessage, ulong> msg, 
            ISocketMessageChannel msgChannel,
            SocketReaction reaction)
        {
            if (msg.Id.Equals(_config.Current.RulesMessageId) &&
                reaction.Emote.Name.Equals(_config.Current.RulesAcceptedEmoteName))
            {
                if (msgChannel is SocketGuildChannel channel)
                {
                    var user = channel.Guild.GetUser(reaction.UserId);
                    var role = channel.Guild.GetRole(_config.Current.RulesAcceptedRoleId);

                    if (user == null)
                    {
                        // Todo: Log
                        return;
                    }
                    
                    if (role == null)
                    {
                        // Todo: Log
                        return;
                    }

                    await user.AddRoleAsync(role);
                }
            }
        }
    }
}