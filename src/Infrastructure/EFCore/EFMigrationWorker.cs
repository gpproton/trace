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
using Trace.Application.Core;
using Trace.Application.Device;
using Trace.Application.Engagement;
using Trace.Application.Tags;
using Trace.Application.Tenant;
using Trace.Application.Vehicle;

namespace Trace.Infrastructure.EFCore;

public class EfMigrationWorker(ILogger<EfMigrationWorker> logger, IServiceScopeFactory factory) : BackgroundService {
    private readonly ServiceContext _context = factory.CreateScope().ServiceProvider.GetRequiredService<ServiceContext>();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        logger.LogInformation("Starting migration...");
        await _context.Database.MigrateAsync(stoppingToken);
        logger.LogInformation("Completed migration...");

        logger.LogInformation("Started seeding data...");

        var dataSeeded = await _context.Set<Tenant>().AnyAsync(stoppingToken);
        if (!dataSeeded) {
            // Seed Tenants
            await _context.Set<Tenant>().AddAsync(new Tenant {
                Active = true ,
                Name = "Local Corp",
                Domains = [ new TenantDomains {  Domain = "localhost" }],
                Profile = new Organization {
                    FullName = "Local Corporation",
                    Name = "Local Corp",
                    Address = new ContactObject { Line1 = "001 X Street", City = "Gos" }
                }
            }, stoppingToken);

            // Seed Tags
            await _context.Set<Tags>().AddAsync(new Tags {
                Name = "Tag-00",
            }, stoppingToken);

            // Seed Contact
            await _context.Set<Contact>().AddAsync(new Contact {
                Email = "john.doe@email.com",
                FirstName = "John",
                LastName = "Doe",
                Address = new ContactExtraObject { Line1 = "Aurora avenue 1", City = "LA", Country = "USA" }
            }, stoppingToken);

            // Seed Vehicles
            await _context.Set<Vehicle>().AddAsync(new Vehicle {
                Id = Guid.NewGuid(),
                SerialNumber = "0001",
                RegistrationNo = "XX 123 XXX",
                FleetIdentifier = "fleet-001",
                // Seed Device
                Device = new Device {
                    UniqueId = "123456",
                    Phone = "+2345678901234"
                }
            }, stoppingToken);

            await _context.SaveChangesAsync(stoppingToken);
            logger.LogInformation("Completed seeding data...");
        }
    }
}