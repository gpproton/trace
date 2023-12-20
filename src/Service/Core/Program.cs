using Trace.Service.Core;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.RegisterPersistence();
builder.Services.RegisterSharedServices();
builder.Services.RegisterHangfire(Nodes.Core);
builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Core)
    .AddQueryType<Query>()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.RegisterDefaults();
app.UseHangfireDashboard(Nodes.Core);
app.RegisterGraphQl();

app.Run();