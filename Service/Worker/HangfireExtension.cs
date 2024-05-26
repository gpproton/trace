// Copyright (c) 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://trace.ng/licenses/license-1-0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Monday, 26th Feb 2024
// Modified By: Godwin peter .O
// Modified At: Wed Apr 24 2024

using Hangfire;
using Hangfire.Redis.StackExchange;
using HangfireBasicAuthenticationFilter;
using StackExchange.Redis;

namespace Trace.Worker.Extensions;

public static class HangfireExtension {
    public static IServiceCollection RegisterHangfire(this IServiceCollection services, string serviceName) {
        services.AddHangfire((sp, config) => {
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseRedisStorage(sp.GetRequiredService<IConnectionMultiplexer>(),
                new RedisStorageOptions {
                    Prefix = $"Job:{serviceName}",
                    ExpiryCheckInterval = TimeSpan.FromHours(1),
                });
        });

        services.AddHangfireServer(options => {
            const string name = "Main";
            options.ServerName = name;
            options.WorkerCount = 5;
            options.Queues = new[] { name };
            options.SchedulePollingInterval = TimeSpan.FromMinutes(1);
        });

        return services;
    }

    public static IApplicationBuilder UseHangfireDashboard(this WebApplication app, string serviceName) {
        var config = app.Services.GetService<IConfiguration>();
        var endpoint = config!.GetValue<string>("Hangfire:Endpoint") ?? "/schedule";

        app.UseHangfireDashboard(endpoint, new DashboardOptions {
            DashboardTitle = $"{serviceName.ToUpper()} Schedule",
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