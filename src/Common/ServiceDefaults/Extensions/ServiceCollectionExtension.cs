using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.OM;
using StackExchange.Redis;

namespace Trace.ServiceDefaults.Extensions;

public static class ServiceCollectionExtension {
    public static IServiceCollection RegisterSchemaHttpClients(this IServiceCollection services,
        IDictionary<string, Uri> schemas) {
        foreach (var schema in schemas) {
            // TODO: Review service discovery HTTP handler
            // services.AddTransient<DiscoveryHttpMessageHandler>();
            // services.AddHttpClient(schema.Key, c => {
            //     ArgumentNullException.ThrowIfNull(schema.Value, "GraphqlEndpoint");
            //     c.BaseAddress = new Uri(schema.Value, string.Empty);
            // })
            // .AddHttpMessageHandler<DiscoveryHttpMessageHandler>();
        }

        return services;
    }

    public static void RegisterDistributedCache(this IServiceCollection services) {
        var sp = services.BuildServiceProvider();
        var config = sp.GetService<IConfiguration>();
        var redisConfig = config!.GetValue<string>("Redis:Client:ConnectionString") ?? "localhost";
        var multiplexer = ConnectionMultiplexer.Connect(redisConfig);

        services.AddSingleton(new RedisConnectionProvider(multiplexer));
        services.AddDataProtection()
            .PersistKeysToStackExchangeRedis(multiplexer)
            .SetApplicationName(Nodes.GroupName);

        services.AddStackExchangeRedisCache(options => {
            options.Configuration = sp.GetRequiredService<ConnectionMultiplexer>().Configuration;
            options.InstanceName = Nodes.GroupName;
        });
        services.AddHttpContextAccessor();
        services.AddSession(o => {
            o.Cookie.Name = $"{Nodes.GroupName}.Session";
            o.IdleTimeout = TimeSpan.FromMinutes(10);
            o.Cookie.IsEssential = true;
        });
    }

    public static WebApplicationBuilder RegisterSharedArchitecture(this WebApplicationBuilder builder) {
        builder.Services.RegisterDistributedCache();
        builder.Services.Configure<FormOptions>(options => {
            options.MultipartBodyLengthLimit = 268435456;
        });

        return builder;
    }
}