using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddRedisDistributedCache("cache");
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapGet("/", () => "Hello");
app.MapDefaultEndpoints();

app.Run();