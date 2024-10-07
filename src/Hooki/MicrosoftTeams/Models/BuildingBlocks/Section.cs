using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Models.Actions;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#openuri-action
/// </summary>
public class Section
{
    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("startGroup")] public bool? StartGroup { get; set; }

    [JsonPropertyName("activityImage")] public string? ActivityImage { get; set; }

    [JsonPropertyName("activityTitle")] public string? ActivityTitle { get; set; }

    [JsonPropertyName("activitySubtitle")] public string? ActivitySubtitle { get; set; }

    [JsonPropertyName("activityText")] public string? ActivityText { get; set; }

    [JsonPropertyName("heroImage")] public Image? HeroImage { get; set; }

    [JsonPropertyName("text")] public string? Text { get; set; }

    [JsonPropertyName("facts")] public List<Fact>? Facts { get; set; }

    [JsonPropertyName("images")] public List<Image>? Images { get; set; }

    [JsonPropertyName("potentialAction")] public List<ActionBase>? PotentialActions { get; set; }
}