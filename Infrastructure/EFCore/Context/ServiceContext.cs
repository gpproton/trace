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
// Created At: Thursday, 11th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using Axolotl.EFCore.Context;
using Axolotl.EFCore.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trace.Application;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Account;
using Trace.Application.Asset;
using Trace.Application.Device;
using Trace.Application.Engagement;
using Trace.Application.Location;
using Trace.Application.Routes;
using Trace.Application.Tags;
using Trace.Application.Tenant;
using Trace.Application.Trailer;
using Trace.Application.Vehicle;
using Tag = Trace.Application.Tags.Tag;

namespace Trace.Infrastructure.EFCore.Context;

public sealed partial class ServiceContext : IdentityDbContext<UserAccount, UserRole, Guid>, IServiceContext {
    private Guid? TenantId { get; set; }
    public ServiceContext() {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(ITenantEntity).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        modelBuilder.RegisterAllEntities<IAggregateRoot>(assembly);
        modelBuilder.RegisterSoftDeleteFilter();
        // TODO: Add condition to exclude manager service
        // RegisterTenantFilter(modelBuilder);
    }

    public DbContext Instance => this;
    public DbSet<Tenant> Tenants { get; set; } = null!;
    public DbSet<TenantSetting> TenantSettings { get; set; } = null!;
    public DbSet<TenantDomain> TenantDomains { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<TagMembers> TagMembers { get; set; } = null!;
    public DbSet<UserAccount> Accounts { get; set; } = null!;
    public DbSet<UserRole> AccountRoles { get; set; } = null!;
    public DbSet<AccountSetting> AccountSettings { get; set; } = null!;
    public DbSet<AccountAlert> AccountAlerts { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Lead> Leads { get; set; } = null!;
    public DbSet<Opportunity> Opportunities { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Trailer> Trailers { get; set; } = null!;
    public DbSet<AssetCategory> AssetCategories { get; set; } = null!;
    public DbSet<Asset> Assets { get; set; } = null!;
    public DbSet<Device> Devices { get; set; } = null!;
    public DbSet<DevicePosition> DevicePositions { get; set; } = null!;
    public DbSet<DeviceCommand> DeviceCommands { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<LocationCategory> LocationCategories { get; set; } = null!;
    public DbSet<Route> Routes { get; set; } = null!;
}