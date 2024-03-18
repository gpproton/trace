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
// Created At: Monday, 26th Feb 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

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