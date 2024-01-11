using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Implementation;

internal class QueueProducer<TQueueMessage>(IQueueChannelProvider<TQueueMessage> channelProvider, ILogger<QueueProducer<TQueueMessage>> logger) : IQueueProducer<TQueueMessage> where TQueueMessage : IQueueMessage {
    private readonly string _queueName = typeof(TQueueMessage).Name;
    private readonly IModel _channel = channelProvider.GetChannel();

    public void PublishMessage(TQueueMessage message) {
        if (Equals(message, default(TQueueMessage))) throw new ArgumentNullException(nameof(message));

        try {
            logger.LogInformation($"Publising message to Queue '{_queueName}'");
            var serializedMessage = SerializeMessage(message);
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.Type = _queueName;

            _channel.BasicPublish(_queueName, _queueName, properties, serializedMessage);

            logger.LogDebug(
                $"Succesfully published message");
        }
        catch (Exception ex) {
            var msg = $"Cannot publish message to Queue '{_queueName}'";
            logger.LogError(ex, msg);
            throw new QueueingException(msg);
        }
    }

    private static byte[] SerializeMessage(TQueueMessage message) {
        var stringContent = JsonSerializer.Serialize(message);
        return Encoding.UTF8.GetBytes(stringContent);
    }
}