using System.Text.Json.Serialization;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Service.Integration.TraccarModel;

public sealed class TraccarEventObject : IQueueMessage {
    [JsonPropertyName("event")]
    public required TraccarEvent Event { get; set; }

    [JsonPropertyName("device")]
    public TraccarDevice Device { get; set; } = default!;

    [JsonPropertyName("position")]
    public TraccarPosition? Position { get; set; }
}
