using System.Threading.Tasks;
using Discord.Commands;
using GodotDiscordBot.Services;

namespace GodotDiscordBot.Modules
{
    public class SimpleBotCommandsModule : ModuleBase<SocketCommandContext>
    {
        private readonly MemeService _memeService;

        public SimpleBotCommandsModule(MemeService memeService)
        {
            _memeService = memeService;
        }

        [Command("meme")]
        [Summary("Posts a random meme")]
        public async Task Meme()
        {
            var (key, value) = _memeService.GetRandomMeme();
            if (key.Length > 0)
            {
                await Context.Channel.SendFileAsync($"memes/{key}",value);
            }
        } 
    }
}