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
// Created At: Tuesday, 2nd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Tue Jan 02 2024

using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Trace.Application.Device;
using Trace.Infrastructure.Cassandra.Implementation;
using Trace.Infrastructure.Cassandra.Interfaces;

namespace Trace.Infrastructure.Cassandra;

public static class CassandraExtension {
    public static IServiceCollection RegisterCassandraInfrastructure(this IServiceCollection services) {
        const string keyspace = CanssandraConst.Keyspace;

        // Registers entities mapping
        services.AddSingleton(_ => new CassandraOptions {
            Keyspace = keyspace,
            Config = [
                DevicePosition.GetConfig(keyspace),
            ]
        });

        var scope = services.BuildServiceProvider();
        var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var cassandraOptions = scope.GetRequiredService<CassandraOptions>();

        services.AddOptions<CassandraConfig>().Bind(config.GetSection(CassandraConfig.Key));
        services.AddSingleton<ICluster>(provider => {
            var conf = provider.GetRequiredService<IOptions<CassandraConfig>>();
            var queryOptions = new QueryOptions().SetConsistencyLevel(ConsistencyLevel.One);

            return Cluster.Builder()
                .AddContactPoint(conf.Value.Host)
                .WithPort(conf.Value.Port)
                .WithCompression(CompressionType.LZ4)
                .WithCredentials(conf.Value.Username, conf.Value.Password)
                .WithQueryOptions(queryOptions)
                .WithRetryPolicy(new LoggingRetryPolicy(new DefaultRetryPolicy()))
                .Build();
        });
        services.AddScoped<ICassandraProvider, CassandraProvider>();

        MappingConfiguration.Global.Define(cassandraOptions.Config);
        services.AddHostedService<CassandraHostedService>();

        return services;
    }
}