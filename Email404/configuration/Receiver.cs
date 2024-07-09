using System.Text.Json.Serialization;

namespace Email404.configuration;

public class Receiver
{
    [JsonPropertyName("mail")] public string Mail { get; set; }

    [JsonPropertyName("groups")] public List<string> Groups { get; set; }
}