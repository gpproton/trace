var builder = DistributedApplication.CreateBuilder(args);

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core");

builder.AddProject<Projects.Trace_Gateway>("gateway")
.WithReference(coreService);

var gateway = builder.AddProject<Projects.Trace_Manager>("manager");

builder.AddProject<Projects.Trace_Frontend>("frontend")
    .WithReference(gateway)
    .WithReference("geocoding", new Uri("https://nominatim.openstreetmap.org"))
    .WithReference("routing", new Uri("https://valhalla.openstreetmap.de/"));

builder.Build().Run();
