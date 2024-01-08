using HotChocolate.Types.Spatial;
using StackExchange.Redis;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.Services.RegisterDefaultServices();
builder.Services.RegisterSchemaHttpClients(Nodes.All.ToDictionary(schema => schema,
    schema => new Uri($"http://service-{schema}/graphql")
));
builder.Services
    .AddGraphQLServer()
    .AddRemoteSchemasFromRedis(Nodes.GroupName, sp => sp.GetRequiredService<IConnectionMultiplexer>())
    .AddHttpRequestInterceptor<RequestInterceptor>()
    .AddType<GeoJsonPositionType>()
    .AddType<GeoJsonCoordinatesType>();
builder.Services
    .AddGraphQL(Nodes.Navigation)
    .AddType<GeoJsonCoordinatesType>();
builder.Services
    .AddGraphQL(Nodes.Integration)
    .AddType<GeoJsonPositionType>()
    .AddType<GeoJsonCoordinatesType>();

var app = builder.Build();

app.RegisterDefaults();
app.RegisterGraphQl();
app.MapGet("/", () => "gateway");

app.Run();