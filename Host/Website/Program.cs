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
// Created At: Saturday, 13th Apr 2024
// Modified By: Godwin peter .O
// Modified At: Sat Apr 13 2024

using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;
using Trace.Infrastructure;
using Trace.Application.Abstractions;
using Trace.Application;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(TenantEntity<>).Assembly;
var isDevelopment = builder.Environment.IsDevelopment();

builder.RegisterDefaults();
builder.AddRedisOutputCache("cache");
builder.RegisterInfrastructure(assembly);
builder.Services.RegisterDefaultServices();
builder.Services.RegisterApplicationServices(assembly);
builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Worker)
    .AddRequestOptions(isDevelopment)
    .AddContextConfig()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles(new StaticFileOptions {
    OnPrepareResponse = ctx => {
        const int durationInSeconds = 60 * 60 * 24 * 365;
        ctx.Context.Response.Headers[HeaderNames.CacheControl] =
            "public,max-age=" + durationInSeconds;
    }
});
app.RegisterDefaults();
app.RegisterGraphQl();
app.UseOutputCache();
app.MapFallbackToFile("index.html");

app.RunWithGraphQLCommands(args);
