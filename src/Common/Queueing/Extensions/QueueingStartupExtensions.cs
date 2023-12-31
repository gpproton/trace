using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Trace.Common.Queueing.Implementation;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Extensions;

public static class QueueingStartupExtensions {
    public static void AddQueueing(this IHostApplicationBuilder builder) {
        var config = builder.Configuration.GetConnectionString("messaging");
        var uri = new Uri(config ?? "amqp://guest:guest@localhost:5672");

        builder.Services.AddSingleton<IAsyncConnectionFactory>(provider => {
            var factory = new ConnectionFactory {
                Uri = uri,
                DispatchConsumersAsync = true,
                AutomaticRecoveryEnabled = true,
                ConsumerDispatchConcurrency = 2
            };

            return factory;
        });

        builder.Services.AddSingleton<IConnectionProvider, ConnectionProvider>();
        builder.Services.AddScoped<IChannelProvider, ChannelProvider>();
        builder.Services.AddScoped(typeof(IQueueChannelProvider<>), typeof(QueueChannelProvider<>));
        builder.Services.AddScoped(typeof(IQueueProducer<>), typeof(QueueProducer<>));
    }

    public static void AddQueueMessageConsumer<TMessageConsumer, TQueueMessage>(this IServiceCollection services) where TMessageConsumer : IQueueConsumer<TQueueMessage> where TQueueMessage : class, IQueueMessage {
        services.AddScoped(typeof(TMessageConsumer));
        services.AddScoped<IQueueConsumerHandler<TMessageConsumer, TQueueMessage>, QueueConsumerHandler<TMessageConsumer, TQueueMessage>>();
        services.AddHostedService<QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage>>();
    }
}
