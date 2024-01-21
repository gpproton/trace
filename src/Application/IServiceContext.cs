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
// Created Date: 2024-1-21 2:13
// Modified By: Godwin peter .O
// Last Modified: 2024-1-21 2:13

using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions.Context;
using Trace.Application.Account;
using Trace.Application.Asset;
using Trace.Application.Device;
using Trace.Application.Engagement;
using Trace.Application.Location;
using Trace.Application.Tags;
using Trace.Application.Tenant;

namespace Trace.Application;

public interface IServiceContext : ICoreContext {
    public DbSet<Tenant.Tenant> Tenants { get; set; }
    public DbSet<TenantSetting> TenantSettings { get; set; }
    public DbSet<TenantDomains> TenantDomains { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagMembers> TagMembers { get; set; }
    public DbSet<UserAccount> Accounts { get; set; }
    public DbSet<UserRole> AccountRoles { get; set; }
    public DbSet<AccountSetting> AccountSettings { get; set; }
    public DbSet<AccountAlert> AccountAlerts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Lead> Leads { get; set; }
    public DbSet<Opportunity> Opportunities { get; set; }
    public DbSet<Application.Vehicle.Vehicle> Vehicles { get; set; }
    public DbSet<Application.Trailer.Trailer> Trailers { get; set; }
    public DbSet<AssetCategory> AssetCategories { get; set; }
    public DbSet<Asset.Asset> Assets { get; set; }
    public DbSet<Device.Device> Devices { get; set; }
    public DbSet<DeviceCommand> DeviceCommands { get; set; }
    public DbSet<Location.Location> Locations { get; set; }
    public DbSet<LocationCategory> LocationCategories { get; set; }
    public DbSet<Application.Routes.Route> Routes { get; set; }
}