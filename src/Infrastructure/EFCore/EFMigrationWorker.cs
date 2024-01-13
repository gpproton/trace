// Copyright 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace License;
// you may not use this file except in compliance with the License.
//     https://mariadb.com/bsl11
//     https://trace.ng/license
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created Date: 2024-1-13 3:15
// Modified By: Godwin peter .O
// Last Modified: 2024-1-13 3:15

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trace.Application;

namespace Trace.Infrastructure.EFCore;

public class EfMigrationWorker (ILogger<EfMigrationWorker> logger, IServiceScopeFactory factory) : BackgroundService {
    private readonly ServiceContext _context = factory.CreateScope().ServiceProvider.GetRequiredService<ServiceContext>();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        logger.LogInformation("Starting migration...");
        await _context.Database.MigrateAsync(stoppingToken);
        logger.LogInformation("Completed migration...");
    }
}