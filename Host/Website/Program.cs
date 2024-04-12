using Trace.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.AddRedisOutputCache("cache");
builder.Services.RegisterDefaultServices();

var app = builder.Build();

app.UseStaticFiles();
app.RegisterDefaults();
app.MapFallbackToFile("index.html");

app.Run();
