// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
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
// Modified At: Thu Mar 21 2024

using Trace.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.AddRedisOutputCache("cache");
builder.Services.RegisterDefaultServices();
// TODO: Refactor later for domain pull
// from database or cache
builder.Services.AddLettuceEncrypt();
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("FrontendProxies"))
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.UseStaticFiles();
app.RegisterDefaults();
app.MapReverseProxy();
app.MapFallbackToFile("index.html");

app.Run();