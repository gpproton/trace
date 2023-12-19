using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddRedis("cache");
builder.AddRedisDistributedCache("cache");
builder.RegisterSharedArchitecture();

builder.Services.AddProblemDetails();
builder.Services.AddCors();
builder.Services.AddAuthorization();

// TODO: fix redis timeout error on aspire
// var endpoints = Nodes.All.ToDictionary(schema => schema,
//     schema => new Uri($"http://service-{schema}")
// );
// builder.Services.RegisterSchemaHttpClients(endpoints);
// builder.Services
//     .AddAuthorization()
//     .AddGraphQLServer()
//     .AddRemoteSchemasFromRedis(Nodes.GroupName, sp => sp.GetRequiredService<IConnectionMultiplexer>())
//     .AddHttpRequestInterceptor<RequestInterceptor>()
//     .AddType<GeoJsonPositionType>()
//     .AddType<GeoJsonCoordinatesType>();
// builder.Services
//     .AddGraphQL(Nodes.Route)
//     .AddType<GeoJsonPositionType>()
//     .AddType<GeoJsonCoordinatesType>();
// builder.Services
//     .AddGraphQL(Nodes.Stream)
//     .AddType<GeoJsonPositionType>()
//     .AddType<GeoJsonCoordinatesType>();

var app = builder.Build();

app.UseAuthorization();
app.UseRouting();
app.UseSession();
app.UseWebSockets();
app.UseCors(o => {
    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

// app.MapBananaCakePop().WithOptions(
//     new GraphQLToolOptions {
//         DisableTelemetry = true
//     });
// app.MapGraphQL().WithOptions(
//     new GraphQLServerOptions {
//         EnableMultipartRequests = true,
//         EnableBatching = true,
//         Tool = {
//             Enable = app.Environment.IsDevelopment()
//         }
//     });

app.MapGet("/", () => "gateway");
app.MapDefaultEndpoints();

app.Run();