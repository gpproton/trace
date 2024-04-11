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
// Created At: Monday, 11th Mar 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

using Trace.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

/** App Services **/
var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core");
var integrationService = builder.AddProject<Projects.Trace_Service_Integration>("service-integration");
var routingService = builder.AddProject<Projects.Trace_Service_Navigation>("service-navigation");
var manager = builder.AddProject<Projects.Trace_Manager>("manager");
var gateway = builder.AddProject<Projects.Trace_Gateway>("gateway");
var frontend = builder.AddProject<Projects.Trace_Frontend>("frontend");

// Only for deployment
if (builder.ExecutionContext.IsPublishMode) {
    var cassandraPort = builder.AddParameter("cassandraPort");
    var cassandraUsername = builder.AddParameter("cassandraUsername");
    var cassandraPassword = builder.AddParameter("cassandraPassword");

    var cache = builder.AddRedis("cache", port: 6379);
    var messaging = builder.AddRabbitMQ("messaging", port: 5672)
    .WithImage("rabbitmq")
    .WithImageTag("3-management-alpine")
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "guest")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "guest");
    var db = builder.AddPostgres("db", port: 5432, password: "trace")
    .WithImage("postgis/postgis")
    .WithImageTag("15-3.3")
    .AddDatabase("trace");
    // TODO: Improve cassandra resource
    builder.AddCassandra("scylladb", 9042, thriftPort: 9160, isProxied: false);

    // Binds containers to services
    coreService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .WithEnvironment("CassandraPort", cassandraPort)
    .WithEnvironment("CassandraUsername", cassandraUsername)
    .WithEnvironment("CassandraPassword", cassandraPassword);

    integrationService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .WithEnvironment("CassandraPort", cassandraPort)
    .WithEnvironment("CassandraUsername", cassandraUsername)
    .WithEnvironment("CassandraPassword", cassandraPassword);

    routingService.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .WithEnvironment("CassandraPort", cassandraPort)
    .WithEnvironment("CassandraUsername", cassandraUsername)
    .WithEnvironment("CassandraPassword", cassandraPassword);

    gateway.WithReference(cache)
    .WithReference(coreService)
    .WithReference(integrationService)
    .WithReference(routingService);

    manager.WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .WithEnvironment("CassandraPort", cassandraPort)
    .WithEnvironment("CassandraUsername", cassandraUsername)
    .WithEnvironment("CassandraPassword", cassandraPassword);

    frontend
        .WithReference(gateway)
        .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
        .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"))
        .WithReference(cache);

}

builder.Build().Run();
