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
// Created At: Wednesday, 3rd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Wed Jan 03 2024

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions;
using Trace.Application.Core.Enums;

namespace Trace.Application.Trailer;

[Index(nameof(UniqueId), IsUnique = true)]
[Index(nameof(Name), nameof(TenantId), IsUnique = true)]
[Index(nameof(FleetIdentifier), nameof(TenantId), IsUnique = true)]
public sealed class Trailer : AssetEntity {
    public Vehicle.Vehicle? Vehicle { get; set; }
    [MaxLength(256)]
    public string? Name { get; set; }
    public TrailerType Type { get; set; }
    [MaxLength(256)]
    public string? FleetIdentifier { get; set; }
    [MaxLength(64)]
    public string? UniqueId { get; set; }
    public long Odometer { get; set; }
    public int HorsePower { get; set; }
    [MaxLength(256)]
    public string? Model { get; set; }
    public decimal WeightCapacity { get; set; }
}