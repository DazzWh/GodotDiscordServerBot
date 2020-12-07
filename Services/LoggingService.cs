using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace GodotDiscordBot.Services
{
    public class LoggingService
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private string LogDirectory { get; }
        private string LogFile => Path.Combine(LogDirectory, $"{DateTime.UtcNow:yyyy-MM-dd}.txt");

        public LoggingService(
            DiscordSocketClient client, 
            CommandService commands)
        {
            _client = client;
            _commands = commands;
            LogDirectory = Path.Combine(AppContext.BaseDirectory, "logs");
        }
        
        public void Initialize()
        {
            _client.Log += Log;
            _commands.Log += Log;
        }

        private Task Log(LogMessage msg)
        {
            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);

            if (!File.Exists(LogFile))
                File.Create(LogFile).Dispose();

            var logText = $"{DateTime.UtcNow:hh:mm:ss} [{msg.Severity}] {msg.Source}: {msg.Exception?.ToString() ?? msg.Message}";
            File.AppendAllText(LogFile, logText + "\n");

            return Console.Out.WriteLineAsync(logText);
        }

    }
}