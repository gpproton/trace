using Hangfire;
using Hangfire.Redis.StackExchange;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Trace.ServiceDefaults.Extensions;

public static class HangfireExtension {
    public static IServiceCollection RegisterHangfire(this IServiceCollection services, string serviceName) {
        services.AddHangfire((sp, config) => {
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseRedisStorage(sp.GetRequiredService<ConnectionMultiplexer>(),
                new RedisStorageOptions {
                    Prefix = $"Job:{serviceName}",
                    ExpiryCheckInterval = TimeSpan.FromHours(1),
                });
        });

        services.AddHangfireServer(options => {
            const string name = "Main";
            options.ServerName = name;
            options.WorkerCount = 5;
            options.Queues = new string[] { name };
            options.SchedulePollingInterval = TimeSpan.FromMinutes(1);
        });

        return services;
    }

    public static IApplicationBuilder UseHangfireDashboard(this WebApplication app, string serviceName) {
        var config = app.Services.GetService<IConfiguration>();
        var endpoint = config!.GetValue<string>("Hangfire:Endpoint") ?? "/schedule";

        app.UseHangfireDashboard(endpoint, new DashboardOptions {
            // DashboardTitle = $"{serviceName.Capitalize()} Schedule",
            Authorization = new[] {
                new HangfireCustomBasicAuthenticationFilter{
                    User = config!.GetValue<string>("Hangfire:Username") ?? "trace",
                    Pass = config!.GetValue<string>("Hangfire:Password") ?? "trace"
                }
            },
        });

        return app;
    }
}