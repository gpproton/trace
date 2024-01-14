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
// Modified At: Tue Jan 02 2024

using Trace.Common.Queueing.Extensions;
using Trace.Infrastructure.Traccar;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;
using Trace.Application;
using Trace.Infrastructure;
using Trace.Application.Abstractions;
using Trace.Service.Integration.Devices;
using Trace.Service.Integration.Protocol;
using Trace.Service.Integration.Protocol.Services;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(TenantEntity<>).Assembly;
var isDevelopment = builder.Environment.IsDevelopment();

builder.RegisterDefaults();
builder.RegisterInfrastructure(assembly);
builder.Services.AddQueueing();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.RegisterTraccarInfrastructure();
builder.Services.RegisterDefaultServices();
builder.Services.RegisterApplicationServices(assembly);
builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Integration)
    .AddRequestOptions(isDevelopment)
    .AddContexConfig()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterDefaults();
app.RegisterGraphQl();
app.MapGrpcService<ProtocolService>();

app.MapProtocolEndpoint();
app.MapDeviceEndpoint();

app.Run();