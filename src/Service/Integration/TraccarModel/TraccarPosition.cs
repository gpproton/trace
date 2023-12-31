using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Trace.Service.Integration.TraccarModel;

public class TraccarPosition {
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("attributes")]
    public JsonObject Attributes { get; set; } = default!;

    [JsonPropertyName("deviceId")]
    public long DeviceId { get; set; }

    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    [JsonPropertyName("serverTime")]
    public DateTimeOffset ServerTime { get; set; }

    [JsonPropertyName("deviceTime")]
    public DateTimeOffset DeviceTime { get; set; }

    [JsonPropertyName("fixTime")]
    public DateTimeOffset FixTime { get; set; }

    [JsonPropertyName("outdated")]
    public bool Outdated { get; set; }

    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("altitude")]
    public double Altitude { get; set; }

    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("course")]
    public double Course { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("accuracy")]
    public double Accuracy { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("geofenceIds")]
    public List<long>? GeofenceIds { get; set; }
}
