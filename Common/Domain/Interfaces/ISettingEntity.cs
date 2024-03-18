// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Trace.Common.Domain.Interfaces;

public interface ISettingEntity {
    public string? Token { get; set; }
    public string? Language { get; set; }
    public string? Timezone { get; set; }
    public bool Hour24Time { get; set; }
    public string? UnitDistance { get; set; }
    public string? UnitVolume { get; set; }
    public string? UnitWeight { get; set; }
    public string? UnitTemperature { get; set; }
    public string? UnitSpeed { get; set; }
    public string? UnitPower { get; set; }
    public string? UnitPressure { get; set; }
    public string? UnitForce { get; set; }
    public string? UnitArea { get; set; }
}