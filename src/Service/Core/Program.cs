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
// builder.Services.RegisterHangfire(Nodes.Core);
// builder.Services..AddGraphQLServer()
//     .AddGraphqlDefaults(Nodes.Core)
//     .AddQueryType<Query>()
//     // .AddMutationType<MutationRoot>()
//     // .AddSubscriptionType<SubscriptionRoot>()
//     .AddQueryableCursorPagingProvider()
//     .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.UseAuthorization();
app.UseRouting();
app.UseSession();
app.UseWebSockets();
app.UseCors(o => {
    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

// app.UseHangfireDashboard(Nodes.Core);
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
app.MapGet("/", () => "service-core");
app.MapDefaultEndpoints();

app.Run();