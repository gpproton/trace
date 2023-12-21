using Trace.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.Services.RegisterSharedServices();

var app = builder.Build();

app.Run();