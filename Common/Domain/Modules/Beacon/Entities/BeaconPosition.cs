// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Trace.Common.Domain.Modules.Beacon.Entities;

public class BeaconPosition : TenantEntity<Guid> {
    public string? Address { get; set; }

    public double Speed { get; set; }

    public double Course { get; set; }

    public double TotalDistance { get; set; }

    public double Altitude { get; set; }

    public double Accuracy { get; set; }

    public int Satellites { get; set; }

    public double? Fuel { get; set; }

    public double? Battery { get; set; }

    public bool Charging { get; set; }

    public DateTimeOffset Time { get; set; }

    public DateTimeOffset ServerTime { get; set; }

    public Beacon? Beacon { get; set; }

    public Guid BeaconId { get; set; }
}