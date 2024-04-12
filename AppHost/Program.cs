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

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core")
    .AddProjectParameters();

var integrationService = builder.AddProject<Projects.Trace_Service_Integration>("service-integration")
    .AddProjectParameters();

var routingService = builder.AddProject<Projects.Trace_Service_Navigation>("service-navigation")
   .AddProjectParameters();

var gateway = builder.AddProject<Projects.Trace_Gateway>("gateway")
    .WithReference(coreService)
    .WithReference(integrationService)
    .WithReference(routingService);

var frontend = builder.AddProject<Projects.Trace_Frontend>("frontend")
    .WithReference(gateway)
    .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
    .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"));

var manager = builder.AddProject<Projects.Trace_Manager>("manager")
    .AddProjectParameters();

if (builder.ExecutionContext.IsRunMode) {
    builder.AddExternalContainer("cache", "cache");
    builder.AddExternalContainer("messaging", "messaging");
    builder.AddExternalContainer("db", "db");
    builder.AddExternalContainer("warehouse", "scylladb");
}

if (builder.ExecutionContext.IsPublishMode) {
    var cache = builder.AddRedis("cache", 6379)
    .WithImage("docker.io/redis/redis-stack-server")
    .WithImageTag("7.2.0-v10");

    var messaging = builder.AddRabbitMQ("messaging", MessagingUser, MessagingPass, 5672);

    var db = builder.AddPostgres("db", DbUser, DbPass, 5432)
        .WithImage("postgis/postgis")
        .WithImageTag("15-3.3")
        .AddDatabase("trace");

    // TODO: Improve cassandra resource
    // builder.AddCassandra("scylladb", 9042, thriftPort: 9160, isProxied: false);
    builder.AddContainer("warehouse", "scylladb/scylla")
       .WithImageTag("5.4")
       .WithEndpoint(targetPort: 9042, scheme: "tcp", name: "cassandra", isProxied: true)
       .WithEndpoint(targetPort: 9160, scheme: "tcp", name: "thrift", isProxied: true);

    coreService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db);

    integrationService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db);

    routingService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db);

    manager.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db);

    gateway.WithReference(cache);
    frontend.WithReference(cache);
}

builder.Build().Run();

public static partial class Program {
    private static IResourceBuilder<ParameterResource>? MessagingUser { get; set; }
    private static IResourceBuilder<ParameterResource>? MessagingPass { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraPort { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraUser { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraPass { get; set; }
    private static IResourceBuilder<ParameterResource>? DbUser { get; set; }
    private static IResourceBuilder<ParameterResource>? DbPass { get; set; }

    private static IResourceBuilder<ProjectResource> AddProjectParameters(this IResourceBuilder<ProjectResource> builder) {
        return builder
            .WithEnvironment("MessagingUser", MessagingUser ?? throw new InvalidOperationException())
            .WithEnvironment("MessagingPass", MessagingPass ?? throw new InvalidOperationException())
            .WithEnvironment("DbUser", DbUser ?? throw new InvalidOperationException())
            .WithEnvironment("DbPass", DbPass ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraPort", CassandraPort ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraUser", CassandraUser ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraPass", CassandraPass ?? throw new InvalidOperationException());
    }
}