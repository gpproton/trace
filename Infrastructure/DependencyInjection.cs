// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://opensource.org/license/rpl-1-5
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Thursday, 11th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using System.Reflection;
using HotChocolate.Execution.Configuration;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Trace.Application;
using Trace.Infrastructure.EFCore;
using Trace.Infrastructure.CacheManager;
using Trace.Infrastructure.Cassandra;
using Trace.Infrastructure.EFCore.Context;
using Trace.Infrastructure.Providers;
using RabbitMQ.Client;

namespace Trace.Infrastructure;

public static class DependencyInjection {
    public static IRequestExecutorBuilder AddContextConfig(this IRequestExecutorBuilder services) {
        services
            // TODO: resolve issues with dbcontext registration
            //.RegisterDbContext<ServiceContext>(DbContextKind.Pooled)
            .AddQueryType<QueryRoot>()
            .AddMutationType<MutationRoot>()
            .AddSubscriptionType<SubscriptionRoot>()
            .AddApplicationTypes();

        return services;
    }

    public static WebApplicationBuilder RegisterInfrastructure(this WebApplicationBuilder builder, Assembly consumersAssembly) {
        const string messagingKey = "messaging";

        builder.AddRabbitMQClient(messagingKey, configureConnectionFactory: factory => {
            if (factory is IAsyncConnectionFactory asyncFactory) asyncFactory.DispatchConsumersAsync = true;
        });

        builder.AddNpgsqlDataSource("trace");
        builder.RegisterCassandraInfrastructure();
        builder.RegisterEfCoreInfrastructure();
        builder.Services.RegisterCacheManager();
        builder.Services.Configure<MassTransitHostOptions>(options => {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromMinutes(5);
            options.StopTimeout = TimeSpan.FromMinutes(1);
        });
        builder.Services.AddMassTransit(busConfigurator => {
            busConfigurator.AddConsumers(consumersAssembly);
            busConfigurator.UsingRabbitMq((context, cfg) => {
                var config = context.GetRequiredService<IConfiguration>();
                cfg.Host(config.GetConnectionString(messagingKey), h => {
                    h.Heartbeat(TimeSpan.FromSeconds(5));
                });
                cfg.ConfigureEndpoints(context);
            });
        });

        builder.Services.AddScoped<ITenantProvider, TenantProvider>();

        // TODO: Section for multi tenancy setup
        // builder.Services.AddMultiTenant<TenantInfo>().WithHostStrategy();

        return builder;
    }
}