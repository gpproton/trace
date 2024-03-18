var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache", port: 6379).PublishAsContainer();
var messaging = builder.AddRabbitMQ("messaging", port: 5672).WithEnvironment("RABBITMQ_DEFAULT_PASS", "guest");
var db = builder.AddPostgres("db", port: 5432, password: "trace")
.WithImage("postgis/postgis")
.WithImageTag("15-3.3")
.AddDatabase("trace");
var scylladb = builder.AddContainer("scylladb", "scylladb/scylla", "5.4")
    .WithEndpoint(containerPort: 9042, scheme: "tcp", name: "default")
    .WithEndpoint(containerPort: 9160, scheme: "tcp", name: "thrift");

// var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core")
// .WithReference(cache)
// .WithReference(messaging)
// .WithReference(db);

// var integrationService = builder.AddProject<Projects.Trace_Service_Integration>("service-integration");
// var routingService = builder.AddProject<Projects.Trace_Service_Navigation>("service-navigation");
// var gateway = builder.AddProject<Projects.Trace_Gateway>("gateway")
//     .WithReference(coreService)
//     .WithReference(integrationService)
//     .WithReference(routingService);
// var manager = builder.AddProject<Projects.Trace_Manager>("manager")
//     .WithReference(integrationService)
//     .WithReference(routingService);
// var frontend = builder.AddProject<Projects.Trace_Frontend>("frontend")
//     .WithReference(gateway)
//     .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
//     .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"));

// coreService.WithReference(cache).WithReference(messaging).WithReference(db);
// integrationService.WithReference(cache).WithReference(messaging).WithReference(db);
// routingService.WithReference(cache).WithReference(messaging).WithReference(db);
// gateway.WithReference(cache);
// manager.WithReference(cache).WithReference(messaging).WithReference(db);
// frontend.WithReference(cache);

builder.Build().Run();