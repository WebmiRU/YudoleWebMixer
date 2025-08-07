using System.Text.Json.Serialization;

namespace YudoleWebMixer;

public class Version
{
    [JsonPropertyName("type")] public string Type { get; init; } = "version";

    [JsonPropertyName("major")] public int Major { get; init; } = 1;

    [JsonPropertyName("minor")] public int Minor { get; init; } = 0;
}

public class Application
{
    [JsonPropertyName("pid")] public uint PID { get; init; }

    [JsonPropertyName("process")] public string? Process { get; init; }

    [JsonPropertyName("name")] public string? Name { get; init; }

    [JsonPropertyName("title")] public string? Title { get; init; }

    [JsonPropertyName("volume")] public required int Volume { get; init; }
}

public class ApplicationsGet
{
    [JsonPropertyName("type")] public string Type { get; init; } = "applications.list";

    [JsonPropertyName("applications")] public List<Application> Applications { get; set; } = new();
}