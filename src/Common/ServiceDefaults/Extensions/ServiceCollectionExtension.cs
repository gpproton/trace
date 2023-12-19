using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Trace.ServiceDefaults.Extensions;

public static class ServiceCollectionExtension {
    public static IServiceCollection RegisterSchemaHttpClients(this IServiceCollection services,
        IDictionary<string, Uri> schemas) {
        foreach (var schema in schemas) {
            services.AddHttpClient(schema.Key, c => {
                ArgumentNullException.ThrowIfNull(schema.Value, "GraphqlEndpoint");
                c.BaseAddress = new Uri(schema.Value, string.Empty);
            });
        }

        return services;
    }

    public static WebApplicationBuilder RegisterSharedArchitecture(this WebApplicationBuilder builder) {
        var sp = builder.Services.BuildServiceProvider();
        var getRedis = sp.GetRequiredService<IConnectionMultiplexer>();

        builder.Services.Configure<HostOptions>(o => {
            o.ServicesStartConcurrently = true;
            o.ServicesStopConcurrently = false;
        });
        builder.Services.AddDataProtection()
            .PersistKeysToStackExchangeRedis(getRedis, "DataProtection-Keys")
            .SetApplicationName(Nodes.GroupName);
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