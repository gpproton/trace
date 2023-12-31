using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Implementation;

internal sealed class ConnectionProvider(ILogger<ConnectionProvider> logger, IAsyncConnectionFactory connectionFactory) : IDisposable, IConnectionProvider {
    private IConnection? _connection;

    public IConnection GetConnection() {
        if (_connection is null || !_connection.IsOpen) {
            logger.LogDebug("Open RabbitMQ connection");
            _connection = connectionFactory.CreateConnection();
        }

        return _connection;
    }

    public void Dispose() {
        try {
            if (_connection != null && _connection.IsOpen) {
                logger.LogDebug("Closing the connection");
                _connection?.Close();
                _connection?.Dispose();
            }
        }
        catch (Exception ex) {
            logger.LogCritical(ex, "Cannot dispose RabbitMq channel or connection");
        }

    }
}
