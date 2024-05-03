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

using Aspire.Hosting.Lifecycle;
using HotChocolate.Fusion.Aspire;
using Trace.AppHost;
using Trace.Common;
using Trace.ServiceDefaults;

var builder = DistributedApplication.CreateBuilder(args);

MessagingUser = builder.AddParameter("MessagingUser");
MessagingPass = builder.AddParameter("MessagingPass");
CassandraHost = builder.AddParameter("CassandraHost");
CassandraPort = builder.AddParameter("CassandraPort");
CassandraUser = builder.AddParameter("CassandraUser");
CassandraPass = builder.AddParameter("CassandraPass");
DbUser = builder.AddParameter("DbUser");
DbPass = builder.AddParameter("DbPass");

if (builder.ExecutionContext.IsRunMode) {
    // TODO: Apply after resolving project root path
    // _ = Task.Run(() => {
    //     var cmd = Cli.Wrap("docker-compose").WithArguments(["up", "-d", "cache", "messaging", "db", "scylladb"]).WithWorkingDirectory("");
    // });

    builder.AddExternalContainer(AppConstants.Cache, AppConstants.Cache);
    builder.AddExternalContainer(AppConstants.Messaging, AppConstants.Messaging);
    builder.AddExternalContainer(AppConstants.Db, AppConstants.Db);
    builder.AddExternalContainer(AppConstants.Scylladb, AppConstants.Scylladb);
}

var workerService = builder.AddProject<Projects.Trace_Service_Worker>($"service-{Nodes.Worker}", launchProfileName: "https")
    .AddProjectParameters();

var coreService = builder.AddProject<Projects.Trace_Service_Core>($"service-{Nodes.Core}", launchProfileName: "https")
    .AddProjectParameters()
    .AsHttp2Service();

var integrationService = builder.AddProject<Projects.Trace_Service_Integration>($"service-{Nodes.Integration}", launchProfileName: "https")
    .AddProjectParameters()
    .AsHttp2Service();

var navigationService = builder.AddProject<Projects.Trace_Service_Navigation>($"service-{Nodes.Navigation}", launchProfileName: "https")
    .AddProjectParameters()
    .AsHttp2Service()
    .WithExternalHttpEndpoints();

var gatewayService = builder.AddFusionGateway<Projects.Trace_Gateway>($"service-{Nodes.Gateway}")
    .WithOptions(new FusionCompositionOptions { EnableGlobalObjectIdentification = true })
    .WithSubgraph(coreService)
    .WithSubgraph(integrationService)
    .WithSubgraph(navigationService);

var frontend = builder.AddProject<Projects.Trace_Frontend>(Nodes.Frontend, launchProfileName: "https")
    .WithReference(integrationService)
    .WithReference(coreService)
    .WithReference(navigationService)
    .WithReference(gatewayService)
    .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
    .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"));


// TODO: Resolve temporary hack
if (builder.ExecutionContext.IsRunMode) {
    frontend.WithEnvironment("services__service-gateway__http__0", "http://localhost:5001")
   .WithEnvironment("services__service-gateway__http__1", "https://localhost:5000");
}

var website = builder.AddProject<Projects.Trace_Host_Website>(Nodes.Website);

var manager = builder.AddProject<Projects.Trace_Manager>(Nodes.Manager)
    .AddProjectParameters();

if (builder.ExecutionContext.IsPublishMode) {
    var cache = builder.AddRedis(AppConstants.Cache, 6379)
    .WithImage("docker.io/redis/redis-stack-server")
    .WithOtlpExporter();

    var messaging = builder.AddRabbitMQ(AppConstants.Messaging, MessagingUser, MessagingPass, 5672)
        .WithDataVolume()
        .WithOtlpExporter();

    var db = builder.AddPostgres(AppConstants.Db, DbUser, DbPass, 5432)
        .WithImage("docker.io/postgis/postgis")
        .WithImageTag("15-3.3")
        .WithDataVolume()
        .WithOtlpExporter();

    var traceDb = db.AddDatabase("trace");

    builder.AddScylladb(AppConstants.Scylladb, port: 9042)
    .WithVolume(AppConstants.Scylladb, "/var/lib/scylla");

    workerService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(traceDb);

    coreService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(traceDb);

    integrationService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(traceDb);

    navigationService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(traceDb);

    gatewayService.WithReference(cache);

    frontend.WithReference(cache)
    .WithEnvironment("services__service-gateway__http__0", "http://service-gateway:80")
    .WithEnvironment("services__service-gateway__http__1", "https://service-gateway:443");

    website.WithReference(cache);

    manager.WithReference(cache)
    .WithReference(messaging)
    .WithReference(traceDb);
}

// builder.Services.AddLifecycleHook<AspNetCoreForwardedHeadersLifecycleHook>();
builder.Build().Compose().Run();

public static partial class Program {
    private static IResourceBuilder<ParameterResource>? MessagingUser { get; set; }
    private static IResourceBuilder<ParameterResource>? MessagingPass { get; set; }
    private static IResourceBuilder<ParameterResource>? CassandraHost { get; set; }
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
            .WithEnvironment("CassandraHost", CassandraHost ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraPort", CassandraPort ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraUser", CassandraUser ?? throw new InvalidOperationException())
            .WithEnvironment("CassandraPass", CassandraPass ?? throw new InvalidOperationException());
    }
}