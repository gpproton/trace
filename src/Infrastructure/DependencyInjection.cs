// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace License
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
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Trace.Infrastructure.EFCore;
using Trace.Infrastructure.Cassandra;
using Trace.Infrastructure.CacheManager;
using Trace.Infrastructure.Providers;

namespace Trace.Infrastructure;

public static class DependencyInjection {
    public static WebApplicationBuilder RegisterInfrastructure(this WebApplicationBuilder builder, Assembly consumerSAsembly) {
        builder.AddRabbitMQ("messaging");
        builder.AddCassandra();
        builder.RegisterEfCoreInfrastructure();
        builder.Services.RegisterCacheManager();
        builder.Services.AddMassTransit(busConfigurator => {
            busConfigurator.AddConsumers(consumerSAsembly);
            busConfigurator.UsingRabbitMq((context, cfg) => {
                var config = context.GetRequiredService<IConfiguration>();
                cfg.Host(config.GetConnectionString("messaging") ?? "amqp://localhost", h => {
                    h.Heartbeat(TimeSpan.FromSeconds(3));
                });
                cfg.ConfigureEndpoints(context);
            });
        });

        builder.Services.AddScoped<ITenantProvider, TenantProvider>();

        return builder;
    }
}