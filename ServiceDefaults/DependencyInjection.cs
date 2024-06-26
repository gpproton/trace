// Copyright (c) 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://trace.ng/licenses/license-1-0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Monday, 26th Feb 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

using System.IO.Compression;
using System.Reflection;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trace.ServiceDefaults.Extensions;

namespace Trace.ServiceDefaults;

public static class DependencyInjection {
    public static WebApplicationBuilder RegisterDefaults(this WebApplicationBuilder builder) {
        var env = builder.Environment;
        var root = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location) ?? env.ContentRootPath;

        builder.Configuration
            .SetBasePath(root)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("config/appsettings.Shared.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"config/appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        if (builder.Environment.IsProduction()) {
            builder.WebHost.ConfigureKestrel((context, options) => {
                var httpsPort = Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORT ") ?? "443";
                options.ListenAnyIP(int.Parse(httpsPort), listenOptions => {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                    listenOptions.UseHttps();
                });
            });
        }

        builder.AddRedisClient("cache");
        builder.AddRedisDistributedCache("cache");
        builder.AddServiceDefaults();
        builder.Services.AddProblemDetails();
        builder.RegisterSharedArchitecture();

        return builder;
    }

    public static IServiceCollection RegisterDefaultServices(this IServiceCollection services) {
        services.AddControllersWithViews();
        services.AddProblemDetails();
        services.AddAntiforgery();
        services.AddAuthorization();
        services.AddCors(options => {
            options.AddDefaultPolicy(
                policy => {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
        });
        services.AddResponseCompression(options => {
            options.Providers.Add<GzipCompressionProvider>();
        });

        services.Configure<GzipCompressionProviderOptions>(options => {
            options.Level = CompressionLevel.Fastest;
        });

        return services;
    }

    public static WebApplication RegisterDefaults(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseHsts();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAntiforgery();
        app.UseAuthorization();
        app.UseSession();
        app.UseWebSockets();
        app.UseResponseCompression();
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

        return app;
    }
}