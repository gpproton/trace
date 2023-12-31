using Trace.Common.Queueing.Interfaces;
using Trace.Service.Integration.TraccarModel;

namespace Trace.Service.Integration.Queue;

public class TraccarPositionConsumer : IQueueConsumer<TraccarPositionObject> {

    private readonly ILogger<TraccarPositionConsumer> _logger;

    public TraccarPositionConsumer(ILogger<TraccarPositionConsumer> logger) {
        _logger = logger;
    }


    public Task ConsumeAsync(TraccarPositionObject message) {
        var attributes = message.Position.Attributes;
        var batteryLevel = attributes["batteryLevel"]!.GetValue<double?>() ?? 0.0;

        _logger.LogInformation($"Device ID: {message.Device.Name}");
        _logger.LogInformation($"Battery Level: {batteryLevel}");

        return Task.CompletedTask;
    }
}
