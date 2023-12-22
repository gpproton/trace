using Trace.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.AddRedisOutputCache("cache");
builder.Services.RegisterDefaultServices();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("FrontendProxies"))
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.RegisterDefaults();
app.MapReverseProxy();
app.MapFallbackToFile("index.html");

app.Run();