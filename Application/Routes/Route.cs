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
// Modified At: Thu Jan 04 2024

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Trace.Application.Abstractions;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Core.Interfaces;

namespace Trace.Application.Routes;

[Index(nameof(Description))]
[Index(nameof(Name), nameof(TenantId), IsUnique = true)]
public class Route : TypedEntity<Guid>, ITaggedEntity, ITenantEntity {
    public Guid? TenantId { get; set; }
    public Guid? ApprovedBy { get; set; }
    public DateTimeOffset ApprovedAt { get; set; }
    [MaxLength(12)]
    public string? Color { get; set; }
    public int? SpeedLimit { get; set; }
    public decimal RestDuration { get; set; }
    public decimal ToleranceDuration { get; set; }
    public int? CompletedRate { get; set; }
    public Point Source { get; set; } = null!;
    public Point Destination { get; set; } = null!;
    public LineString? Path { get; set; }
    public ICollection<Tags.Tag> Tags { get; set; } = [];
}