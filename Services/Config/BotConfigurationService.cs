using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Discord;

namespace GodotDiscordBot.Services.Config
{
    public class BotConfigurationService
    {
        
        public event Func<LogMessage, Task> Log;
        private BotConfiguration _config;

        public void Initialize()
        {
            _config = LoadConfiguration();
        }

        public string GetDiscordToken() => _config.DiscordToken;

        private static BotConfiguration LoadConfiguration()
        {
            var config = new BotConfiguration(); 

            try
            {
                var serializer = new XmlSerializer(typeof(BotConfiguration), new XmlRootAttribute("config"));
                var stringReader = new StreamReader("config.xml");
                config = (BotConfiguration) serializer.Deserialize(stringReader);
            }
            catch (Exception e)
            {
                // Todo: Log why this fails
                // Log?.Invoke(new LogMessage(LogSeverity.Error, nameof(GameService), e.Message));
            }

            return config;
        }
    }
}