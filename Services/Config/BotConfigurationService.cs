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
        public BotConfiguration Current;

        public void Initialize()
        {
            Current = LoadConfiguration();
        }
        
        private BotConfiguration LoadConfiguration()
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
                Log?.Invoke(new LogMessage(LogSeverity.Error, nameof(BotConfigurationService), e.Message));
            }

            return config;
        }
    }
}