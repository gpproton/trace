var builder = DistributedApplication.CreateBuilder(args);

// var cache = builder.AddRedisContainer("cache", port: 6379);
// var messaging = builder.AddRabbitMQContainer("messaging", port: 5672, password: "guest");

// var db = builder.AddPostgresContainer("db", port: 5432, password: "trace")
// .WithAnnotation(new ContainerImageAnnotation { Image = "postgis/postgis", Tag = "15-3.3" })
// .AddDatabase("trace");

// TODO: enable after scylladb config
// var scylladb = builder.AddContainer("scylladb", "scylladb/scylla", "5.4")
//     .WithServiceBinding(containerPort: 9042, scheme: "tcp", name: "default")
//     .WithServiceBinding(containerPort: 9160, scheme: "tcp", name: "thrift");

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core");
// .WithReference(cache)
// .WithReference(messaging)
// .WithReference(db);

var integrationService = builder.AddProject<Projects.Trace_Service_Integration>("service-integration");
// .WithReference(cache)
// .WithReference(messaging)
// .WithReference(db);

var routingService = builder.AddProject<Projects.Trace_Service_Routing>("service-routing");
// .WithReference(cache)
// .WithReference(messaging)
// .WithReference(db);

var gateway = builder.AddProject<Projects.Trace_Gateway>("gateway")
    // .WithReference(cache)
    .WithReference(coreService)
    .WithReference(integrationService)
    .WithReference(routingService);

builder.AddProject<Projects.Trace_Manager>("manager")
    // .WithReference(cache)
    // .WithReference(messaging)
    // .WithReference(db)
    .WithReference(integrationService)
    .WithReference(routingService);

builder.AddProject<Projects.Trace_Frontend>("frontend")
    // .WithReference(cache)
    .WithReference(gateway)
    .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
    .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"));

builder.Build().Run();
