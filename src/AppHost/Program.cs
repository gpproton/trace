var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache")
    .WithAnnotation(new ContainerImageAnnotation { Image = "docker.io/redis/redis-stack", Tag = "7.2.0-v6" });

var messaging = builder.AddRabbitMQContainer("rabbitmq")
    .WithAnnotation(new ContainerImageAnnotation { Image = "docker.io/rabbitmq", Tag = "3-management-alpine" })
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "admin")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "secret");

var warehouse = builder.AddContainer("warehouse", "docker.io/scylladb/scylla", "5.4")
    .WithServiceBinding(containerPort: 9042, scheme: "tcp", name: "default")
    .WithServiceBinding(containerPort: 9160, scheme: "tcp", name: "thrift");

var db = builder.AddPostgresContainer("db")
.WithAnnotation(new ContainerImageAnnotation { Image = "docker.io/postgis/postgis", Tag = "15-3.3" })
.AddDatabase("tracedb");

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core")
    .WithReference(cache)
    .WithReference(messaging)
    .WithReference(db)
    .WithEnvironment("SCYLLA_URL", warehouse.GetEndpoint("default"));

builder.AddProject<Projects.Trace_Gateway>("gateway")
    .WithReference(cache)
    .WithReference(coreService);

builder.Build().Run();
