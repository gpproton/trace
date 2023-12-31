using Trace.Service.Routing;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.RegisterPersistence();
builder.Services.RegisterDefaultServices();
builder.Services.RegisterHangfire(Nodes.Routing);
builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Routing)
    .AddQueryType<Query>()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.RegisterDefaults();
app.UseHangfireDashboard(Nodes.Routing);
app.RegisterGraphQl();

app.Run();