// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Trace.Common.Domain.Modules.Beacon.Enums;

namespace Trace.Common.Domain.Modules.Beacon.Entities;

public class Beacon : TenantEntity<Guid> {
    public string FleetNo { get; set; } = String.Empty;

    public string Phone { get; set; } = String.Empty;

    public BeaconStatus Status { get; set; }

    public DateTimeOffset? LastUpdate { get; set; }

    public BeaconDevice? Device { get; set; }

    public Guid? DeviceId { get; set; }

    public Guid? PositionId { get; set; }

    public Location.Entities.Location? Location { get; set; }

    public Guid? LocationId { get; set; }
}