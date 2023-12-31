using RabbitMQ.Client;

namespace Trace.Common.Queueing.Interfaces;

public interface IChannelProvider {
    IModel GetChannel();
}
