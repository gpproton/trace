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
using Yarp.ReverseProxy.Forwarder;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDefaults();
builder.AddRedisOutputCache("cache");
builder.Services.RegisterDefaultServices();
builder.Services.AddHttpForwarderWithServiceDiscovery();
// TODO: Refactor later for domain pull
// from database or cache
// builder.Services.AddLettuceEncrypt();

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.RegisterDefaults();

var geocodingUrl = app.Configuration.GetValue<string>("services:geocoding") ?? "http://geocoding";
var routingUrl = app.Configuration.GetValue<string>("services:routing") ?? "http://routing";
var requestConfig = ForwarderRequestConfig.Empty;

app.MapForwarder("/api/service", $"http://service-{Nodes.Gateway}/graphql", requestConfig, (proxy) => {
    proxy.AddPathRemovePrefix("/api/service");
});
app.MapForwarder("/api/geocoding/{**catch-all}", geocodingUrl, requestConfig, (proxy) => {
    proxy.AddPathRemovePrefix("/api/geocoding");
});
app.MapForwarder("/api/routing/{**catch-all}", routingUrl, requestConfig, (proxy) => {
    proxy.AddPathRemovePrefix("/api/routing");
});

app.UseOutputCache();
app.MapFallbackToFile("index.html");

app.Run();