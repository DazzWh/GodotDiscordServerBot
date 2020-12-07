using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;

namespace GodotDiscordBot.Modules
{
    public class SimpleLinksModule : ModuleBase<SocketCommandContext>
    {
        // Godot Links
        [Command("api")]
        [Summary("Latest stable documentation link")]
        public async Task Api() => await ReplyAsync("https://docs.godotengine.org/en/stable/classes/index.html");

        [Command("csharp")]
        [Summary("C# documentation link")]
        public async Task CSharp() => await ReplyAsync("https://godotsharp.net/");
        
        [Command("step")]
        [Summary("Official step-by-step tutorial")]
        public async Task Step() => await ReplyAsync("https://docs.godotengine.org/en/stable/getting_started/step_by_step/index.html");
        
        [Command("nightly")]
        [Summary("Calinou's nightly Godot builds")]
        public async Task Nightly() => await ReplyAsync("https://hugo.pro/projects/godot-builds/");
        
        [Command("mirror")]
        [Summary("Unofficial Godot download mirror (for people experiencing slowness with the official mirror).")]
        public async Task Mirror() => await ReplyAsync("https://archive.hugo.pro/godot-tuxfamily/");
        
        [Command("tut")]
        [Summary("List of community tutorials in the Godot documentation")]
        public async Task Tut() => await ReplyAsync("https://docs.godotengine.org/en/stable/community/tutorials.html");
        
        [Command("lang")]
        [Summary("Programming language support in Godot")]
        public async Task Lang() => await ReplyAsync("https://github.com/Vivraan/godot-lang-support");
        
        [Command("consoles")]
        [Summary("Documentation page 'Console support in Godot'")]
        public async Task Consoles() => await ReplyAsync("https://docs.godotengine.org/en/stable/tutorials/platform/consoles.html");

        [Command("class")]
        [Summary("Links to a given class in the godot documentation")]
        public async Task Class(
            [Summary("The class to link to")] string className)
        {
            
            if (className.Length == 0)
            {
                await ReplyAsync("Usage: !class [class]");
                return;
            }
            
            var classRegex = new Regex(@"^[a-zA-Z0-9@_]+$");
            if (!classRegex.IsMatch(className))
            {
                await ReplyAsync("Invalid class name (must not contain spaces or special characters other than `@` and `_`).");
                return;
            }
            
            // Percent-encode the `@` symbol to prevent highlighting users on Discord.
            // And lower the case as document urls are case sensitive  
            var classNameEscaped = className.Replace("@", "%40").ToLower();
            await ReplyAsync($"https://docs.godotengine.org/en/stable/classes/class_{classNameEscaped}.html");
        }

        // Discord help
        [Command("code")]
        [Summary("Instructions for syntax highlighting and code formatting")]
        public async Task Code() => await ReplyAsync("You can format and syntax highlight your GDScript code by putting **\\`\\`\\`swift** a line above it, and **\\`\\`\\`** a line below it.");
        
        [Command("ask")]
        [Summary("Reminder to not ask to ask! Just do it!")]
        public async Task Ask() => await ReplyAsync("You do not need to ask for permission to ask a question. Just ask your question and anyone that can help will answer you as soon as possible.");

        // Popular tutorial creator channels.
        [Command("gdquest")]
        [Summary("GdQuest Youtube Channel")]
        public async Task GdQuest() => await ReplyAsync("https://www.youtube.com/channel/UCxboW7x0jZqFdvMdCFKTMsQ");

        [Command("kcc")]
        [Summary("Kids Can Code YouTube channel")]
        public async Task Kcc() => await ReplyAsync("https://www.youtube.com/channel/UCNaPQ5uLX5iIEHUCLmfAgKg/");

        [Command("heart")]
        [Summary("GdQuest Youtube Channel")]
        public async Task Heart() => await ReplyAsync("https://www.youtube.com/c/uheartbeast/");

        [Command("bcg")]
        [Summary("Born CG YouTube channel")]
        public async Task Bgc() => await ReplyAsync("https://www.youtube.com/playlist?list=PLda3VoSoc_TSBBOBYwcmlamF1UrjVtccZ");

        // Misc
        [Command("game")]
        [Summary("Expresses game making motivation")]
        public async Task Game() => await ReplyAsync("https://imgur.com/a/egsXCBs");
        
        [Command("patterns")]
        [Summary("Game Programming Patterns book (online version)")]
        public async Task Patterns() => await ReplyAsync("https://gameprogrammingpatterns.com/contents.html");
        
        [Command("pronounce")]
        [Summary("How to pronounce the word 'Godot'")]
        public async Task Pronounce() => await ReplyAsync("Godot is usually pronounced \"go-dough\" (the \"t\" is silent).");
        
    }
}