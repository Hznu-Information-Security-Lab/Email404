using System.Text.Json.Serialization;

namespace Email404.configuration;

public class Group
{
    [JsonPropertyName("name")] public string Name { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("data")] public Data Data { get; set; }
}