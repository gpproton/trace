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
// Modified At: Thu Jan 11 2024

using Cassandra;
using Cassandra.Data.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trace.Application.Device;
using Trace.Infrastructure.Cassandra.Interfaces;

namespace Trace.Infrastructure.Cassandra;

public class CassandraHostedService(ILogger<CassandraHostedService> logger, ICluster cluster, IServiceScopeFactory factory, CassandraOptions options) : IHostedService {
    public async Task StartAsync(CancellationToken cancellationToken) {
        var scope = factory.CreateScope().ServiceProvider;
        var bootSession = cluster.Connect();

        logger.LogInformation("Creating cassandra default keyspace");
        bootSession.CreateKeyspaceIfNotExists(options.Keyspace);

        try {
            var cassandraProvider = scope.GetRequiredService<ICassandraProvider>();
            using (var session = cassandraProvider.GetSession()) {
                await new Table<DevicePosition>(session).CreateIfNotExistsAsync();
            };
        }
        catch (Exception) {
            logger.LogInformation("Tables creation failed");
            throw;
        }

        var keyspaces = new List<string>(cluster.Metadata.GetKeyspaces());
        keyspaces.ForEach((value) => {
            if (value == options.Keyspace) {
                logger.LogInformation("KeySpace: " + value);
                new List<string>(cluster.Metadata.GetKeyspace(value).GetTablesNames()).ForEach((tableName) => {
                    Console.WriteLine("Table: " + tableName);
                });
            }
        });
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        logger.LogInformation("Finishing cassandra background activities");
        return Task.CompletedTask;
    }
}
