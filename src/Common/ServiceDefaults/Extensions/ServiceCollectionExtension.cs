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

    public static WebApplicationBuilder RegisterSharedArchitecture(this WebApplicationBuilder builder) {
        // TODO: fix redis timeout error on aspire
        // var sp = builder.Services.BuildServiceProvider();
        // var getRedis = sp.GetRequiredService<IConnectionMultiplexer>();
        // var getRedisConfig = getRedis.Configuration;
        // var multiplexer = ConnectionMultiplexer.Connect(getRedisConfig);
        // builder.Services.AddSingleton(multiplexer);

        // builder.Services.AddDataProtection()
        //     .PersistKeysToStackExchangeRedis(getRedis, "DataProtection-Keys")
        //     .SetApplicationName(Nodes.GroupName);

        // builder.Services.AddStackExchangeRedisCache(options => {
        //     options.Configuration = getRedisConfig;
        //     options.InstanceName = Nodes.GroupName;
        // });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSession(o => {
            o.Cookie.Name = $"{Nodes.GroupName}.Session";
            o.IdleTimeout = TimeSpan.FromMinutes(10);
            o.Cookie.IsEssential = true;
        });

        builder.Services.Configure<FormOptions>(options => {
            options.MultipartBodyLengthLimit = 268435456;
        });

        return builder;
    }
}