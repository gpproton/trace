using Trace.Service.Integration;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.RegisterPersistence();
builder.Services.RegisterDefaultServices();
builder.Services.RegisterHangfire(Nodes.Integration);
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