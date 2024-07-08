using System.Text.Json.Serialization;

namespace Email404;

public class Configuration
{
    [JsonPropertyName("receivers")] public List<Receiver> Receivers { get; set; }

    [JsonPropertyName("groups")] public List<Group> Groups { get; set; }

    public static Configuration Empty => new() { Receivers = new List<Receiver>(), Groups = new List<Group>() };
}

public class Group
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("data")] public Data Data { get; set; }
}

public class Data
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("members")]
    public List<string> Members { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Receiver
{
    [JsonPropertyName("mail")] public string Mail { get; set; }

    [JsonPropertyName("groups")] public List<string> Groups { get; set; }
}