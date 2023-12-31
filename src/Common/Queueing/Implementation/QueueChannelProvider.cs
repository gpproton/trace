using RabbitMQ.Client;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Implementation;

internal class QueueChannelProvider<TQueueMessage>(IChannelProvider channelProvider) : IQueueChannelProvider<TQueueMessage> where TQueueMessage : IQueueMessage {
    private IModel? _channel;
    private readonly string _queueName = typeof(TQueueMessage).Name;

    public IModel GetChannel() {
        _channel ??= channelProvider.GetChannel();

        DeclareQueueAndDeadLetter();
        return _channel;
    }

    private void DeclareQueueAndDeadLetter() {
        var queueArgs = new Dictionary<string, object> {
            { "x-queue-type", "quorum" },
            { "overflow", "reject-publish" }
        };

        if (_channel is not null) {
            _channel.ExchangeDeclare(_queueName, ExchangeType.Topic, durable: true, autoDelete: false);
            _channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false, arguments: queueArgs);
            _channel.QueueBind(_queueName, _queueName, _queueName, null);
        }
    }
}
