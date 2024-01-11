using Microsoft.Extensions.Logging;
using Trace.Common.Queueing.Interfaces;
using Trace.Infrastructure.Traccar.Model;

namespace Trace.Infrastructure.Traccar.Queue;

public class TraccarPositionConsumer(ILogger<TraccarPositionConsumer> logger) : IQueueConsumer<TraccarPositionObject> {
    public Task ConsumeAsync(TraccarPositionObject message) {
        var attributes = message.Position.Attributes;
        var batteryLevel = attributes["batteryLevel"]!.GetValue<double?>() ?? 0.0;

        logger.LogInformation($"Device ID: {message.Device.Name}; Battery Level: {batteryLevel}");

        return Task.CompletedTask;
    }
}