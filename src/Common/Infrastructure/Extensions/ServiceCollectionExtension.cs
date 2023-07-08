using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.OM;
using StackExchange.Redis;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Connector.Redis;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Extensions.Configuration.Kubernetes;
using Steeltoe.Extensions.Logging.DynamicSerilog;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Endpoint.DbMigrations;
using Steeltoe.Management.Tracing;
using Steeltoe.Security.DataProtection;

namespace Trace.Common.Infrastructure.Extensions;

public static class ServiceCollectionExtension {
    public static IServiceCollection RegisterSchemaHttpClients(this IServiceCollection services,
        IDictionary<string, Uri> schemas) {
        foreach (var schema in schemas) {
            services.AddTransient<DiscoveryHttpMessageHandler>();
            services.AddHttpClient(schema.Key, c => {
                ArgumentNullException.ThrowIfNull(schema.Value, "GraphqlEndpoint");
                c.BaseAddress = new Uri(schema.Value, string.Empty);
            })
            .AddHttpMessageHandler<DiscoveryHttpMessageHandler>();
        }

        return services;
    }

    public static void RegisterDistributedCache(this IServiceCollection services) {
        var sp = services.BuildServiceProvider();
        var config = sp.GetService<IConfiguration>();
        var redisConfig = config!.GetValue<string>("Redis:Client:ConnectionString") ?? "localhost";


        var multiplexer = ConnectionMultiplexer.Connect(redisConfig);

        services.AddSingleton(new RedisConnectionProvider(multiplexer));
        services.AddDistributedRedisCache(config);
        services
        .AddDataProtection()
        .PersistKeysToRedis()
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
        var env = builder.Environment;
        var config = builder.Configuration;

        config.SetBasePath(env.ContentRootPath)
        .AddYamlFile("config.yaml", optional: true, reloadOnChange: true)
        .AddYamlFile($"config.{env.EnvironmentName}.yaml", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
        .AddKubernetes()
        .AddConfigServer()
        .AddEnvironmentVariables();

        builder.Logging.AddDynamicSerilog();
        builder.Services.AddRedisConnectionMultiplexer(config);
        builder.Services.RegisterDistributedCache();
        builder.Services.AddServiceDiscovery(o => o.UseConsul());
        builder.Services.AddAllActuators(config);
        builder.Services.ActivateActuatorEndpoints();
        builder.Services.AddDistributedTracingAspNetCore();
        builder.Services.AddDistributedTracing();
        builder.Services.AddSpringBootAdminClient();
        builder.Services.AddDbMigrationsActuator();
        builder.Services.Configure<FormOptions>(options => {
            options.MultipartBodyLengthLimit = 268435456;
        });

        return builder;
    }
}