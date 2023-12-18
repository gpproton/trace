using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using MQTTnet.Server;
using Trace.Common.Infrastructure;

namespace Trace.ServiceDefaults.Mqtt;

public class QueueController {
    public static QueueController CreateInstance() {
        return new QueueController();
    }

    internal static Task OnClientConnected(ClientConnectedEventArgs eventArgs) {
        var logger = Initializer.GetLogger<WebApplication>();
        logger.LogInformation("Client '{id}' connected.", eventArgs.ClientId);
        return Task.CompletedTask;
    }

    internal static Task ValidateConnection(ValidatingConnectionEventArgs eventArgs) {
        var logger = Initializer.GetLogger<WebApplication>();
        logger.LogInformation("Client '{id}' ants to connect. Accepting!", eventArgs.ClientId);
        return Task.CompletedTask;
    }
}