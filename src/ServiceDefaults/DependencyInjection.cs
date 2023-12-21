// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Reflection;
using FluentValidation;
using HotChocolate.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trace.ServiceDefaults.Extensions;

namespace Trace.ServiceDefaults;

public static class DependencyInjection {
    public static WebApplicationBuilder RegisterDefaults(this WebApplicationBuilder builder) {
        var env = builder.Environment;
        var root = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location) ?? env.ContentRootPath;

        builder.Configuration
            .SetBasePath(root)
            .AddJsonFile("config/appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("config/appsettings.Shared.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"config/appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        builder.AddRedis("cache");
        builder.AddRedisDistributedCache("cache");
        builder.AddServiceDefaults();
        builder.RegisterSharedArchitecture();

        return builder;
    }

    public static WebApplicationBuilder RegisterPersistence(this WebApplicationBuilder builder) {
        builder.AddRabbitMQ("messaging");
        // TODO: Hook up shared DbContext
        // builder.AddNpgsqlDbContext<OperationContext>("db");

        var rabbitMqConnectionString = builder.Configuration.GetConnectionString("messaging") ?? "localhost";
        builder.Services.AddMassTransit(x => {
            x.AddHangfireConsumers();
            x.UsingRabbitMq((context, cfg) => {
                cfg.Host(rabbitMqConnectionString, h => {
                    h.Heartbeat(TimeSpan.Zero);
                    h.Username("admin");
                    h.Password("secret");
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return builder;
    }

    public static IServiceCollection RegisterDefaultServices(this IServiceCollection services) {
        services.AddProblemDetails();
        services.AddCors();
        services.AddAntiforgery();
        services.AddAuthorization();

        return services;
    }

    public static WebApplication RegisterDefaults(this WebApplication app) {
        app.UseRouting();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.UseAuthorization();
        app.UseSession();
        app.UseWebSockets();
        app.UseCors(o => {
            o.AllowAnyOrigin();
            o.AllowAnyMethod();
            o.AllowAnyHeader();
        });
        app.MapDefaultEndpoints();

        return app;
    }

    public static WebApplication RegisterGraphQl(this WebApplication app) {
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

        return app;
    }

    public static IServiceCollection RegisterService(this IServiceCollection services, Assembly assembly) {

        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}