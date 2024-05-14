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
// Created At: Tuesday, 23rd Apr 2024
// Modified By: Godwin peter .O
// Modified At: Wed Apr 24 2024

using Trace.ServiceDefaults;
using Trace.Infrastructure;
using Trace.Application;
using Trace.Application.Abstractions;
using Trace.Infrastructure.EFCore;
using Trace.Infrastructure.Cassandra;
using Trace.Worker.Extensions;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(TenantEntity<>).Assembly;
var isDevelopment = builder.Environment.IsDevelopment();

builder.RegisterDefaults();
builder.RegisterInfrastructure(assembly);
builder.Services.RegisterDefaultServices();
builder.Services.RegisterApplicationServices(assembly);
// TODO: Temporary
builder.Services.RegisterHangfire(Nodes.Core);
builder.Services.AddHostedService<EfMigrationWorker>();
builder.Services.AddHostedService<CassandraHostedService>();

var app = builder.Build();

app.RegisterDefaults();
app.UseHangfireDashboard(Nodes.Worker);
app.MapGet("/", () => "service.worker");

app.Run();
