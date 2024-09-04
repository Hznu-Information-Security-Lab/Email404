using System.Text.Json.Serialization;

namespace Email404.configuration;

public class Receiver
{
    [JsonPropertyName("mail")] public required string Mail { get; set; }

    [JsonPropertyName("enable")] public bool Enabled { get; set; } = true;
    [JsonPropertyName("groups")] public required List<string> Groups { get; set; } = [];
}