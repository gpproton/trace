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
// Created At: Monday, 18th Mar 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

using System.Net.Sockets;

namespace Trace.AppHost;

public static class CassandraExtensions {
    public static IResourceBuilder<CassandraResource> AddCassandra(this IDistributedApplicationBuilder builder, string name, int? hostPort = null, int? thriftPort = null, bool isProxied = true) {

        return builder.AddResource(new CassandraResource(name))
            .WithAnnotation(new ContainerImageAnnotation { Image = "scylladb/scylla", Tag = "5.4" })
            .WithEndpoint(containerPort: 9042, hostPort: hostPort, scheme: "tcp", name: "cassandra", isProxied: isProxied)
            .WithEndpoint(containerPort: 9160, hostPort: thriftPort, scheme: "tcp", name: "thrift", isProxied: isProxied);
    }
}

public class CassandraResource(string name) : Resource(name), IResourceWithConnectionString, IResourceWithEnvironment {

    public string? GetConnectionString() {
        if (!this.TryGetAllocatedEndPoints(out var endpoints)) throw new InvalidOperationException("Resource has not been allocated yet");

        var endpoint = endpoints.Where(a => a.Name != "cassandra").Single();
        return $"{endpoint.Address}";
    }

    public CassandraOptions GetConfig() {
        if (!this.TryGetEnvironmentVariables(out var env)) throw new InvalidOperationException("Resource has not been allocated yet");
        if (!this.TryGetAllocatedEndPoints(out var endpoints)) throw new InvalidOperationException("Resource has not been allocated yet");
        var cassandra = endpoints.Where(a => a.Name != "cassandra").Single();

        return new CassandraOptions {
            Address = cassandra.Address,
            Port = cassandra.Port
        };
    }
}

public class CassandraOptions {
    public int? Port { get; set; } = 9042;
    public string? Address { get; set; }
}