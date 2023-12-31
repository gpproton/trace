using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Trace.Service.Integration.TraccarModel;

public class TraccarDevice {
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("attributes")]
    public JsonObject Attributes { get; set; } = default!;

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("calendarId")]
    public long CalendarId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("uniqueId")]
    public string UniqueId { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("lastUpdate")]
    public DateTimeOffset? LastUpdate { get; set; }

    [JsonPropertyName("positionId")]
    public long PositionId { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; } = string.Empty;

    [JsonPropertyName("model")]
    public string? Model { get; set; } = string.Empty;

    [JsonPropertyName("contact")]
    public string? Contact { get; set; } = string.Empty;

    [JsonPropertyName("category")]
    public string? Category { get; set; } = string.Empty;

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("expirationTime")]
    public DateTimeOffset? ExpirationTime { get; set; }
}
