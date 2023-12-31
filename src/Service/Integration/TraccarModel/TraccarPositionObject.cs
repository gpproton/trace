using System.Text.Json.Serialization;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Service.Integration.TraccarModel;

public class TraccarPositionObject : IQueueMessage {
    [JsonPropertyName("device")]
    public TraccarDevice Device { get; set; } = default!;

    [JsonPropertyName("position")]
    public TraccarPosition Position { get; set; } = default!;
}
