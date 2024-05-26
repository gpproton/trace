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
// Created At: Monday, 18th Mar 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

namespace Trace.AppHost;

public static class ScylladbExtensions {
    public static IResourceBuilder<ScylladbResource> AddScylladb(this IDistributedApplicationBuilder builder, string name, int? port = null, bool isProxied = true) {

        return builder.AddResource(new ScylladbResource(name))
            .WithImage("scylladb/scylla")
            .WithImageTag("5.4")
            .WithOtlpExporter()
            .WithEndpoint(targetPort: 9042, port: port, scheme: "tcp", name: "scylladb", isProxied: isProxied);
    }
}

public class ScylladbResource(string name) : ContainerResource(name), IResourceWithEnvironment {
    public string? GetConnectionString() {
        if (!this.TryGetEndpoints(out var endpoints)) throw new InvalidOperationException("Resource has not been allocated yet");

        var endpoint = endpoints.Single(a => a.Name != "scylladb");

        return $"{endpoint?.AllocatedEndpoint?.Address}";
    }

    public ScylladbOptions GetConfig() {
        if (!this.TryGetEnvironmentVariables(out var env)) throw new InvalidOperationException("Resource has not been allocated yet");
        if (!this.TryGetEndpoints(out var endpoints)) throw new InvalidOperationException("Resource has not been allocated yet");


        var scylladb = endpoints.Single(a => a.Name != "scylladb");

        return new ScylladbOptions {
            Address = scylladb?.AllocatedEndpoint?.Address,
            Port = scylladb?.Port
        };
    }
}

public class ScylladbOptions {
    public int? Port { get; set; } = 9042;
    public string? Address { get; set; }
}