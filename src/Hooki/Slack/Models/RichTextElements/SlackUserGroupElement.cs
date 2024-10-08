using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class SlackUserGroupElement : ISlackRichTextElement
{
    [JsonPropertyName("type")] public SlackRichTextElementType Type => SlackRichTextElementType.UserGroup;
    
    [JsonPropertyName("usergroup_id")] public required string UserGroupId { get; set; }
    
    [JsonPropertyName("style")] public SlackAdvancedTextStyle? Style { get; set; }
}