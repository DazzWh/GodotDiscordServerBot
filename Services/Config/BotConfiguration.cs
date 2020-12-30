using System.Xml.Serialization;
using Discord;

namespace GodotDiscordBot.Services.Config
{
    [XmlType("config")]
    public class BotConfiguration
    {
        [XmlElement("DiscordToken")] public string DiscordToken = string.Empty;
        
        [XmlElement("ShowcaseChannelId")] public ulong ShowcaseChannelId = 0;
        [XmlElement("ShowcaseAutoEmote")] public string ShowcaseAutoEmoteName = string.Empty;
        
        [XmlElement("RulesMessageId")] public ulong RulesMessageId = 0;
        [XmlElement("RulesAcceptedEmoteName")] public string RulesAcceptedEmoteName = string.Empty;
        [XmlElement("RulesAcceptedRoleId")] public ulong RulesAcceptedRoleId = 0;
    }
}