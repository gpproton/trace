// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace License
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://opensource.org/license/rpl-1-5
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Sat Jan 06 2024

using System.IO.Compression;
using System.Reflection;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
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

    public static IServiceCollection RegisterDefaultServices(this IServiceCollection services) {
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
        app.UseRouting();
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
        app.MapDefaultEndpoints();

        return app;
    }
}