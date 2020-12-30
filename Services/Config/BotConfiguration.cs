using System.Xml.Serialization;

namespace GodotDiscordBot.Services.Config
{
    [XmlType("config")]
    public class BotConfiguration
    {
        [XmlElement("DiscordToken")]
        public string DiscordToken = string.Empty;
    }
}