using HotChocolate.AspNetCore;
using Trace.Service.Core;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddRedis("cache");
builder.AddRabbitMQ("messaging");
builder.AddRedisDistributedCache("cache");
builder.RegisterSharedArchitecture();
// TODO: Hook up shared DbContext

builder.Services.AddProblemDetails();
builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.RegisterHangfire(Nodes.Core);
builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Core)
    .AddQueryType<Query>()
    // TODO: Recreate mutation and subscription types
    // .AddMutationType<MutationRoot>()
    // .AddSubscriptionType<SubscriptionRoot>()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.UseAuthorization();
app.UseRouting();
app.UseSession();
app.UseWebSockets();
app.UseCors(o => {
    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHangfireDashboard(Nodes.Core);
app.MapBananaCakePop().WithOptions(
    new GraphQLToolOptions {
        DisableTelemetry = true
    });
app.MapGraphQL().WithOptions(
    new GraphQLServerOptions {
        EnableMultipartRequests = true,
        EnableBatching = true,
        Tool = {
            Enable = app.Environment.IsDevelopment()
        }
    });
app.MapDefaultEndpoints();

app.Run();