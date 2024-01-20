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
// Modified At: Thu Jan 18 2024

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions;
using Trace.Application.Core.Enums;
using Trace.Application.Core.Interfaces;
using Trace.Application.Tags;

namespace Trace.Application.Vehicle;

[Index(nameof(TrailerId), IsUnique = true)]
[Index(nameof(DeviceId), IsUnique = true)]
[Index(nameof(RegistrationNo), nameof(TenantId), IsUnique = true)]
[Index(nameof(FleetIdentifier), nameof(TenantId), IsUnique = true)]
public sealed class Vehicle : AssetEntity, ITaggedEntity {
    public VehicleVariant Type { get; set; } = VehicleVariant.Truck;
    [MaxLength(64)]
    public string FleetIdentifier { get; set; } = null!;
    [MaxLength(64)]
    public string RegistrationNo { get; set; } = null!;
    public long Odometer { get; set; }
    public FuelType FuelType { get; set; }
    public int FuelCapacity { get; set; }
    public int HorsePower { get; set; }
    [MaxLength(256)]
    public string? Model { get; set; }
    public decimal WeightCapacity { get; set; }
    public Trailer.Trailer? Trailer { get; set; }
    public Guid? TrailerId { get; set; }
    public Device.Device? Device { get; set; }
    public Guid? DeviceId { get; set; }
    public ICollection<Tag> Tags { get; set; } = [];
}