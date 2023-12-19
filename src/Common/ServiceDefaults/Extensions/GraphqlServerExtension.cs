using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Trace.ServiceDefaults.Extensions;

public static class GraphqlServerExtension {
    public static IRequestExecutorBuilder AddGraphqlDefaults(this IRequestExecutorBuilder services, string? name = null) {
        services
        .InitializeOnStartup()
        .AddSorting()
        .AddFiltering()
        .AddProjections()
        .AddType<UploadType>()
        .UseAutomaticPersistedQueryPipeline()
        .AddRedisQueryStorage(sp => sp.GetRequiredService<ConnectionMultiplexer>().GetDatabase())
        // .RegisterDbContext<OperationContext>(DbContextKind.Pooled)
        .AddApolloTracing()
        .AddMutationConventions(applyToAllMutations: true)
        .AddRedisSubscriptions(sp => sp.GetRequiredService<ConnectionMultiplexer>())
        .ModifyRequestOptions(opt => {
            opt.Complexity.ApplyDefaults = true;
            opt.Complexity.DefaultComplexity = 1;
            opt.Complexity.DefaultResolverComplexity = 5;
        });

        if (name is not null)
            services.PublishSchemaDefinition(c => {
                c.SetName(name)
                .PublishToRedis(Nodes.GroupName,
                    sp => sp.GetRequiredService<ConnectionMultiplexer>());
            });

        return services;
    }
}