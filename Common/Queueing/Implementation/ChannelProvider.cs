using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Implementation;

internal sealed class ChannelProvider(IConnection connection,
    // TODO: Review necessity of using factory directly
    // IConnectionProvider connectionProvider,
    ILogger<ChannelProvider> logger) : IDisposable, IChannelProvider {
    private IModel? _model;

    public IModel GetChannel() {
        if (_model is null || !_model.IsOpen) {
            logger.LogDebug("Opening RabbitMQ channel");
            _model = connection.CreateModel();
            logger.LogDebug($"Created RabbitMQ channel {_model.ChannelNumber}");
        }

        return _model;
    }

    public void Dispose() {
        try {
            if (_model != null && _model.IsOpen) {
                logger.LogDebug($"Closing RabbitMQ channel {_model.ChannelNumber}");
                _model?.Close();
                _model?.Dispose();
            }
        }
        catch (Exception ex) {
            logger.LogCritical(ex, "Cannot dispose RabbitMq channel or connection");
        }
    }
}