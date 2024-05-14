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
// Created At: Monday, 22nd Apr 2024
// Modified By: Godwin peter .O
// Modified At: Thu May 02 2024

using HotChocolate;
using HotChocolate.Types.Spatial;
using Trace.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterDefaults();
builder.Services.RegisterDefaultServices();
builder.Services.AddHttpForwarderWithServiceDiscovery();
builder.Services.AddCors()
    .AddHeaderPropagation(c => {
        c.Headers.Add("GraphQL-Preflight");
        c.Headers.Add("Authorization");
    });
builder.Services
    .AddHttpClient("Fusion")
    .AddHeaderPropagation();

var fusion = builder.Services.AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp", watchFileForUpdates: true)
    .AddServiceDiscoveryRewriter();

builder.Services
    .AddGraphQL()
    .AddType<GeometryType>()
    .AddType<GeoJsonPositionType>()
    .AddType<GeoJsonCoordinatesType>();

var app = builder.Build();
app.RegisterDefaults();
app.UseHeaderPropagation();
app.RegisterGraphQl();
app.MapGet("/", () => "service.gateway");
app.RunWithGraphQLCommands(args);