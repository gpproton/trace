var builder = DistributedApplication.CreateBuilder(args);

var coreService = builder.AddProject<Projects.Trace_Service_Core>("service-core");

builder.AddProject<Projects.Trace_Gateway>("gateway")
.WithReference(coreService);

builder.Build().Run();
