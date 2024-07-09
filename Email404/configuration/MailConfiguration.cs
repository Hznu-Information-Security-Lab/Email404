using System.Text.Json.Serialization;

namespace Email404.configuration;

public class MailConfiguration
{
    [JsonPropertyName("username")] public string UserName { get; set; }
    [JsonPropertyName("password")] public string PassWord { get; set; }
    [JsonPropertyName("host")] public string Host { get; set; }
    [JsonPropertyName("senderMail")] public string SenderMail { get; set; }
}