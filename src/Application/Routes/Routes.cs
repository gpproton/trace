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

using NetTopologySuite.Geometries;
using Trace.Application.Core;

namespace Trace.Application.Routes;

public class Routes : TaggedEntity<Guid> {
    public Guid? ApprovedBy { get; set; }
    public DateTimeOffset ApprovedAt { get; set; }
    public string? Color { get; set; }
    public int? SpeedLimit { get; set; }
    public decimal RestDuration { get; set; }
    public decimal ToleranceDuration { get; set; }
    public int? CompletedRate { get; set; }
    public Point Source { get; set; } = null!;
    public Point Destination { get; set; } = null!;
    public LineString? Path { get; set; }
}