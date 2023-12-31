using Trace.Common.Queueing.Interfaces;
using Trace.Service.Integration.TraccarModel;

namespace Trace.Service.Integration;

public class TraccarEventConsumer(ILogger<TraccarEventConsumer> logger) : IQueueConsumer<TraccarEventObject> {
    public Task ConsumeAsync(TraccarEventObject message) {
        logger.LogInformation($"Event Type: {message.Event.Type}; Device ID: {message.Device.Name}; Event Id: {message.Event.Id}");

        return Task.CompletedTask;
    }
}
