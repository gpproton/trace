using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using MQTTnet.AspNetCore;

namespace Trace.ServiceDefaults.Extensions;

public static class MqttExtension {
    public static WebApplicationBuilder RegisterMqttService(this WebApplicationBuilder builder) {
        var port = builder.Configuration.GetValue<int>("Mqtt:Port");
        var backlogCount = builder.Configuration.GetValue<int>("Mqtt:BacklogCount");

        builder.Services.AddHostedMqttServer(options => {
            options
            .WithPersistentSessions()
            .WithDefaultEndpoint()
            .WithConnectionBacklog(backlogCount)
            .WithDefaultEndpointPort(port);
        })
        .AddMqttConnectionHandler()
        .AddConnections()
        .AddMqttTcpServerAdapter();

        return builder;
    }

    public static void UseMqtt(this WebApplication app) {
        var config = app.Services.GetService<IConfiguration>();
        var path = config!.GetValue<string?>("MQTT:Path") ?? "/iot";

        app.MapMqtt(path);
        app.UseMqttServer(server => {
            // server.ValidatingConnectionAsync += QueueController.ValidateConnection;
            // server.ClientConnectedAsync += QueueController.OnClientConnected;
            server.StartedAsync += async (sender) => {
                while (true) {
                    try {
                        var msg = new MqttApplicationMessageBuilder().WithPayload("welcome to mqtt").WithTopic("start");
                        msg.Build();
                        msg.WithPayload("you are welcome to mqtt");
                    }
                    catch (Exception e) {
                        Console.WriteLine(e);
                    }
                    finally {
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            };
        });

    }
}