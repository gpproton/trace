using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Implementation;

internal class QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage>(ILogger<QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage>> logger,
    IServiceProvider serviceProvider) : IHostedService where TMessageConsumer : IQueueConsumer<TQueueMessage> where TQueueMessage : class, IQueueMessage {
    private IQueueConsumerHandler<TMessageConsumer, TQueueMessage>? _consumerHandler;
    private IServiceScope? _scope;

    public Task StartAsync(CancellationToken cancellationToken) {
        logger.LogInformation($"Registering {typeof(TMessageConsumer).Name} as Consumer for Queue {typeof(TQueueMessage).Name}");
        _scope = serviceProvider.CreateScope();

        _consumerHandler = _scope.ServiceProvider.GetRequiredService<IQueueConsumerHandler<TMessageConsumer, TQueueMessage>>();
        _consumerHandler.RegisterQueueConsumer();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        logger.LogInformation($"Stop {nameof(QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage>)}: Canceling {typeof(TMessageConsumer).Name} as Consumer for Queue {typeof(TQueueMessage).Name}");

        _consumerHandler?.CancelQueueConsumer();
        _scope?.Dispose();

        return Task.CompletedTask;
    }
}
