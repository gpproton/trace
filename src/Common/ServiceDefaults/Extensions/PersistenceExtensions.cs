using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trace.ServiceDefaults.Extensions;

public static class PersistenceExtensions {
    public static IServiceCollection RegisterSharedDataConnector(this IServiceCollection services) {
        var sp = services.BuildServiceProvider();
        var config = sp.GetService<IConfiguration>();
        var postgresConfig = config!.GetValue<string>("Postgres:Client:ConnectionString");

        // services.AddRabbitMQConnection(config);
        // services.AddRabbitServices(true);
        // services.AddRabbitAdmin();
        // services.AddRabbitTemplate();
        // services.AddPostgresHealthContributor(config);
        // services.AddDbContext<OperationContext>(options =>
        // options.UseSnakeCaseNamingConvention()
        // .UseNpgsql(postgresConfig, b => b
        //     .MigrationsAssembly(typeof(OperationContext).Assembly.FullName)
        //     .EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null)
        //     .UseNetTopologySuite()));

        // services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        // services.AddScoped(typeof(IReadRepository<>), typeof(GenericRepository<>));

        services.Configure<JsonOptions>(options => {
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        return services;
    }
}