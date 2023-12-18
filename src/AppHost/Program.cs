var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache")
    .WithAnnotation(new ContainerImageAnnotation { Image = "docker.io/redis/redis-stack", Tag = "7.2.0-v6" });

var messaging = builder.AddRabbitMQContainer("messaging")
    .WithAnnotation(new ContainerImageAnnotation { Image = "docker.io/rabbitmq", Tag = "3-management-alpine" })
    // .WithServiceBinding(containerPort: 15672, scheme: "http")
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "admin")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "secret");

var warehouse = builder.AddContainer("warehouse", "docker.io/scylladb/scylla", "5.4")
    .WithServiceBinding(containerPort: 9042, scheme: "tcp")
    .WithServiceBinding(containerPort: 9160, scheme: "tcp");

var traceDb = builder.AddPostgresContainer("trace-db")
.WithAnnotation(new ContainerImageAnnotation { Image = "docker.io/postgis/postgis", Tag = "15-3.3" })
.WithEnvironment("PGDATA", "/var/lib/postgresql/data/pgdata")
.WithEnvironment("POSTGRES_USER", "trace")
.WithEnvironment("POSTGRES_PASSWORD", "trace")
.WithEnvironment("POSTGRES_DB", "trace")
.AddDatabase("trace");

var gatewayService = builder.AddProject<Projects.Trace_Gateway>("gateway")
    .WithReference(cache);

builder.Build().Run();
