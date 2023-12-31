using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Trace.Service.Integration;

public class TraccarEvent {
    [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("attributes")]
        public JsonObject Attributes { get; set; } = default!;

        [JsonPropertyName("deviceId")]
        public long DeviceId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("eventTime")]
        public DateTimeOffset EventTime { get; set; }

        [JsonPropertyName("positionId")]
        public long PositionId { get; set; }

        [JsonPropertyName("geofenceId")]
        public long GeofenceId { get; set; }

        [JsonPropertyName("maintenanceId")]
        public long MaintenanceId { get; set; }
}
