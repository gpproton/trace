using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Implementation;

internal class QueueConsumerHandler<TMessageConsumer, TQueueMessage>(IServiceProvider serviceProvider,
    ILogger<QueueConsumerHandler<TMessageConsumer, TQueueMessage>> logger) : IQueueConsumerHandler<TMessageConsumer, TQueueMessage> where TMessageConsumer : IQueueConsumer<TQueueMessage> where TQueueMessage : class, IQueueMessage {

    private readonly string _queueName = typeof(TQueueMessage).Name;
    private IModel? _consumerRegistrationChannel;
    private string? _consumerTag;
    private readonly string _consumerName = typeof(TMessageConsumer).Name;


    public void RegisterQueueConsumer() {
        var scope = serviceProvider.CreateScope();
        _consumerRegistrationChannel = scope.ServiceProvider.GetRequiredService<IQueueChannelProvider<TQueueMessage>>().GetChannel();

        var consumer = new AsyncEventingBasicConsumer(_consumerRegistrationChannel);
        consumer.Received += HandleMessage;
        try {
            _consumerTag = _consumerRegistrationChannel.BasicConsume(_queueName, false, consumer);
        }
        catch (Exception ex) {
            var exMsg = $"BasicConsume failed for Queue '{_queueName}'";
            logger.LogError(ex, exMsg);
            throw new QueueingException(exMsg);
        }
    }

    public void CancelQueueConsumer() {
        try {
            _consumerRegistrationChannel?.BasicCancel(_consumerTag);
        }
        catch (Exception ex) {
            var message = $"Error canceling QueueConsumer registration for {_consumerName}";
            logger.LogError(message, ex);
            throw new QueueingException(message, ex);
        }
    }

    private async Task HandleMessage(object ch, BasicDeliverEventArgs ea) {
        var consumerScope = serviceProvider.CreateScope();
        var consumingChannel = ((AsyncEventingBasicConsumer)ch).Model;

        IModel? producingChannel = null;
        try {
            producingChannel = consumerScope.ServiceProvider.GetRequiredService<IChannelProvider>()
                .GetChannel();
            var message = DeserializeMessage(ea.Body.ToArray());
            producingChannel.TxSelect();
            var consumerInstance = consumerScope.ServiceProvider.GetRequiredService<TMessageConsumer>();
            await consumerInstance.ConsumeAsync(message);
            if (producingChannel.IsClosed || consumingChannel.IsClosed) {
                throw new QueueingException("A channel is closed during processing");
            }
            producingChannel.TxCommit();
            consumingChannel.BasicAck(ea.DeliveryTag, false);
        }
        catch (Exception ex) {
            var msg = $"Cannot handle consumption of a {_queueName} by {_consumerName}'";
            logger.LogError(ex, msg);
            RejectMessage(ea.DeliveryTag, consumingChannel, producingChannel!);
        }
        finally {
            consumerScope.Dispose();
        }
    }

    private void RejectMessage(ulong deliveryTag, IModel consumeChannel, IModel scopeChannel) {
        try {
            scopeChannel?.TxRollback();
            consumeChannel.BasicReject(deliveryTag, false);
        }
        catch (Exception bex) {
            var bexMsg =
                $"BasicReject failed";
            logger.LogCritical(bex, bexMsg);
        }
    }

    private static TQueueMessage DeserializeMessage(byte[] message) {
        var stringMessage = Encoding.UTF8.GetString(message);
        var data = JsonSerializer.Deserialize<TQueueMessage>(stringMessage)!;

        return data;
    }
}