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
// Created At: Thursday, 11th Apr 2024
// Modified By: Godwin peter .O
// Modified At: Thu Apr 11 2024

using Trace.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

MessagingUser = builder.AddParameter("MessagingUser");
MessagingPass = builder.AddParameter("MessagingPass");
CassandraPort = builder.AddParameter("CassandraPort");
CassandraUser = builder.AddParameter("CassandraUser");
CassandraPass = builder.AddParameter("CassandraPass");
DbUser = builder.AddParameter("DbUser");
DbPass = builder.AddParameter("DbPass");

var cache = builder.AddRedis("cache", 6379)
    .WithRedisCommander()
    .WithImage("docker.io/redis/redis-stack-server")
    .WithImageTag("7.2.0-v10")
    .WithOtlpExporter();

var messaging = builder.AddRabbitMQ("messaging", MessagingUser, MessagingPass, 5672)
    .WithDataVolume()
    .WithManagementPlugin()
    .WithImage("masstransit/rabbitmq")
    .WithOtlpExporter();

ScyllaResource = builder.AddContainer("scylladb", "scylladb/scylla", "5.4")
    .WithVolume("scylladb", "/var/lib/scylla")
    // .WithArgs("-u", CassandraUser.ToString() ?? "cassandra", "-p", CassandraPass.ToString() ?? "cassandra") // -u cassandra -p cassandra
    .WithOtlpExporter()
    .WithEndpoint(targetPort: 9042, port: 9042, name: "default", scheme: "tcp", isProxied: true);

var db = builder.AddPostgres("db", DbUser, DbPass, 5432)
    .WithImage("postgis/postgis")
    .WithImageTag("15-3.3")
    .WithDataVolume()
    .WithPgAdmin()
    .WithOtlpExporter()
    .AddDatabase("trace");

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core")
    .WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .AddProjectParameters();

var integrationService = builder.AddProject<Projects.Trace_Service_Integration>("service-integration")
.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .AddProjectParameters();

var routingService = builder.AddProject<Projects.Trace_Service_Navigation>("service-navigation")
    .WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
   .AddProjectParameters();

var gatewayService = builder.AddProject<Projects.Trace_Gateway>("service-gateway")
    .WithReference(cache)
    .WithReference(coreService)
    .WithReference(integrationService)
    .WithReference(routingService);

var frontend = builder.AddProject<Projects.Trace_Frontend>("frontend")
    .WithReference(cache)
    .WithReference(gatewayService)
    .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
    .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"));

var website = builder.AddProject<Projects.Trace_Host_Website>("website").WithReference(cache);

var manager = builder.AddProject<Projects.Trace_Manager>("manager")
    .WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .AddProjectParameters();

builder.Build().Run();

public static partial class Program {
    private static IResourceBuilder<ParameterResource>? MessagingUser { get; set; }
    private static IResourceBuilder<ParameterResource>? MessagingPass { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraPort { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraUser { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraPass { get; set; }
    private static IResourceBuilder<ParameterResource>? DbUser { get; set; }
    private static IResourceBuilder<ParameterResource>? DbPass { get; set; }
    private static IResourceBuilder<ContainerResource>? ScyllaResource { get; set; }

    private static IResourceBuilder<ProjectResource> AddProjectParameters(this IResourceBuilder<ProjectResource> builder) {
        var cassandraHost = ScyllaResource?.GetEndpoint("default").Host ?? "localhost";
        var cassandraPort = ScyllaResource?.GetEndpoint("default").Port.ToString() ?? "9042";

        return builder
            .WithEnvironment("MessagingUser", MessagingUser ?? throw new InvalidOperationException())
            .WithEnvironment("MessagingPass", MessagingPass ?? throw new InvalidOperationException())
            .WithEnvironment("DbUser", DbUser ?? throw new InvalidOperationException())
            .WithEnvironment("DbPass", DbPass ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraHost", cassandraHost)
            .WithEnvironment("CassandraPort", cassandraPort)
            .WithEnvironment("CassandraUser", CassandraUser ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraPass", CassandraPass ?? throw new InvalidOperationException());
    }
}