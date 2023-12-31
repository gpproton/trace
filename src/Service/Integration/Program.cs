using Trace.Common.Queueing.Extensions;
using Trace.Service.Integration;
using Trace.Service.Integration.Queue;
using Trace.Service.Integration.TraccarModel;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.RegisterPersistence();
builder.AddQueueing();
builder.Services.RegisterDefaultServices();
builder.Services.RegisterHangfire(Nodes.Integration);

builder.Services.AddQueueMessageConsumer<TraccarPositionConsumer, TraccarPositionObject>();

builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Integration)
    .AddQueryType<Query>()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.RegisterDefaults();
app.UseHangfireDashboard(Nodes.Integration);
app.RegisterGraphQl();

app.Run();