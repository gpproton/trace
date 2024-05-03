// Copyright 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0;
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
// Created Date: 2024-1-22 23:18
// Modified By: Godwin peter .O
// Last Modified: 2024-1-22 23:18

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Redis.OM.Modeling;
using Trace.Application.Abstractions;
using Trace.Application.Abstractions.Interfaces;

namespace Trace.Application.Protocol;

[Index(nameof(TenantId))]
public abstract class BasePosition : ExtendedEntity, ITenantEntity {
    [Indexed]
    public Guid? TenantId { get; set; }
    [Indexed]
    public DateTimeOffset Time { get; set; }
    [Indexed]
    public DateTimeOffset ServerTime { get; set; }
    [Indexed]
    public double Longitude { get; set; }
    [Indexed]
    public double Latitude { get; set; }
    [Indexed]
    [MaxLength(1024)]
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
    public double Fuel { get; set; }
    [Indexed]
    public double Battery { get; set; }
    public bool Charging { get; set; }
    [Indexed]
    protected ICollection<Guid> LocationIds { get; set; } = [];
}