using RabbitMQ.Client;

namespace Trace.Common.Queueing.Interfaces;

internal interface IConnectionProvider {
    IConnection GetConnection();
}