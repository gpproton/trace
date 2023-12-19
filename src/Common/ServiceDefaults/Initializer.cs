using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Trace.ServiceDefaults;

public static class Initializer {
    internal static ILogger GetLogger<T>() {
        var loggerFactory = LoggerFactory.Create(builder => {
            builder.ClearProviders();
            builder.AddConsole();
        });

        return loggerFactory.CreateLogger<T>();
    }
}