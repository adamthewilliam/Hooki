using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Header
{
    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;
}