// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Trace.Common.Infrastructure;
using Trace.Common.Service;
using Trace.Common.Standard;
using Trace.Worker.DefaultServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterService();
builder.Services.AddHostedService<MaintenanceWorker>();
builder.Services.AddHostedService<MigrationService>();
builder.Services.AddHostedService<IndexCreationWorker>();

var app = builder.Build();
app.RegisterInfrastructure(option);
app.Run();