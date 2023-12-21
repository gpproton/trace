using Microsoft.FluentUI.AspNetCore.Components;
using Trace.Manager.Client.Pages;
using Trace.Manager.Components;
using Trace.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.Services.RegisterSharedServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
}
else {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.RegisterDefaults();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
