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
// Created At: Thursday, 11th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using System.ComponentModel.DataAnnotations;
using Cassandra.Mapping;
using Redis.OM.Modeling;
using Trace.Application.Abstractions;
using Trace.Application.Core.Interfaces;
using Trace.Common.Warehouse.Interfaces;

namespace Trace.Application.Device;

[Document(StorageType = StorageType.Hash, Prefixes = [nameof(DevicePosition)])]
public class DevicePosition : ExtendedEntity, ICassandraEntity<Guid>, ITenantEntity {
    public const string KeyMotion = "motion";
    public const string KeyPower = "power"; // volts
    public const string KeyBattery = "battery"; // volts
    public const string KeyBatteryLevel = "batteryLevel"; // percentage
    public const string KeyFuelLevel = "fuel"; // liters
    public const string KeyFuelUsed = "fuelUsed"; // liters
    public const string KeyFuelConsumption = "fuelConsumption";
    public const string KeyIgnition = "ignition";
    public const string KeyAntenna = "antenna";
    public const string KeyCharge = "charge";

    [Indexed]
    [Key]
    public Guid Id { get; set; }
    [Indexed]
    public Guid? TenantId { get; set; }
    [Indexed]
    [RedisIdField]
    public Guid DeviceId { get; set; }
    [Indexed]
    public DateTimeOffset Time { get; set; }
    [Indexed]
    public DateTimeOffset ServerTime { get; set; }
    [Indexed]
    public double Longitude { get; set; }
    [Indexed]
    public double Latitude { get; set; }
    [Indexed]
    public string? Address { get; set; }
    [Indexed]
    public double Speed { get; set; }
    [Indexed]
    public double Course { get; set; }
    [Indexed]
    public double Distance { get; set; }
    [Indexed]
    public double Odometer { get; set; }
    [Indexed]
    public double Altitude { get; set; }
    [Indexed]
    public int Satellites { get; set; }
    [Indexed]
    public double? Fuel { get; set; }
    [Indexed]
    public double? Battery { get; set; }
    public bool Charging { get; set; }
    [Indexed]
    public ICollection<Guid> LocationIds { get; set; } = [];

    public static Map<DevicePosition> GetConfig(string keyspace) {
        return new Map<DevicePosition>()
            .KeyspaceName(keyspace)
            .TableName("positions")
            .PartitionKey(x => x.Id)
            .Column(x => x.Id, x => x.WithName("id"))
            .Column(x => x.TenantId, x => x.WithName("tenant_id"))
            .Column(x => x.DeviceId, x => x.WithName("device_id"))
            .Column(x => x.Time, x => x.WithName("time"))
            .Column(x => x.ServerTime, x => x.WithName("server_time"))
            .Column(x => x.Longitude, x => x.WithName("longitude"))
            .Column(x => x.Latitude, x => x.WithName("latitude"))
            .Column(x => x.Address, x => x.WithName("address"))
            .Column(x => x.Speed, x => x.WithName("speed"))
            .Column(x => x.Course, x => x.WithName("course"))
            .Column(x => x.Distance, x => x.WithName("distance"))
            .Column(x => x.Odometer, x => x.WithName("odometer"))
            .Column(x => x.Altitude, x => x.WithName("altitude"))
            .Column(x => x.Satellites, x => x.WithName("satellites"))
            .Column(x => x.Fuel, x => x.WithName("fuel"))
            .Column(x => x.Charging, x => x.WithName("charging"))
            .Column(x => x.LocationIds, x => x.WithName("location_ids"));
    }
}