var builder = DistributedApplication.CreateBuilder(args);

#if !DEBUG
var cache = builder.AddRedisContainer("cache", port: 6379);
var messaging = builder.AddRabbitMQContainer("messaging", port: 5672, password: "guest");
var db = builder.AddPostgresContainer("db", port: 5432, password: "trace")
.WithAnnotation(new ContainerImageAnnotation { Image = "postgis/postgis", Tag = "15-3.3" })
.AddDatabase("trace");
var scylladb = builder.AddContainer("scylladb", "scylladb/scylla", "5.4")
    .WithServiceBinding(containerPort: 9042, scheme: "tcp", name: "default")
    .WithServiceBinding(containerPort: 9160, scheme: "tcp", name: "thrift");
#endif

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core");
var integrationService = builder.AddProject<Projects.Trace_Service_Integration>("service-integration");
var routingService = builder.AddProject<Projects.Trace_Service_Navigation>("service-navigation");
var gateway = builder.AddProject<Projects.Trace_Gateway>("gateway")
    .WithReference(coreService)
    .WithReference(integrationService)
    .WithReference(routingService);
var manager = builder.AddProject<Projects.Trace_Manager>("manager")
    .WithReference(integrationService)
    .WithReference(routingService);
var frontend = builder.AddProject<Projects.Trace_Frontend>("frontend")
    .WithReference(gateway)
    .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
    .WithReference("routing", new Uri("https://valhalla.openstreetmap.de"));

#if !DEBUG
coreService.WithReference(cache).WithReference(messaging).WithReference(db);
integrationService.WithReference(cache).WithReference(messaging).WithReference(db);
routingService.WithReference(cache).WithReference(messaging).WithReference(db);
gateway.WithReference(cache);
manager.WithReference(cache).WithReference(messaging).WithReference(db);
frontend.WithReference(cache);
#endif

builder.Build().Run();