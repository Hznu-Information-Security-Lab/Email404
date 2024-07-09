using System.Text.Json.Serialization;

namespace Email404.configuration;

public class Configuration
{
    [JsonPropertyName("receivers")] public List<Receiver> Receivers { get; init; }

    [JsonPropertyName("groups")] public List<Group> Groups { get; init; }

    [JsonPropertyName("mail")] public MailConfiguration Mail { get; init; }

    public static Configuration Empty => new() { Receivers = [], Groups = [], Mail = new MailConfiguration() };
}