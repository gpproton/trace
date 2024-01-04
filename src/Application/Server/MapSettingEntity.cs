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
// Created Date: 2024-1-4 8:11
// Modified By: Godwin peter .O
// Last Modified: 2024-1-4 8:11

using Trace.Application.Core.Interfaces;

namespace Trace.Application.Server;

public class MapSettingEntity : IMapSettingEntity {
    public string? MapType { get; set; }
    public int? Zoom { get; set; }
    public int? ZoomSelection { get; set; }
    public bool EnableTrip { get; set; }
    public bool AutoRoute { get; set; }
    public bool AutoOrder { get; set; }
    public bool AutoRouteCost { get; set; }
    public bool AutoInvoice { get; set; }
    public bool VerifyOtp { get; set; }
    public bool AutoZoneOtp { get; set; }
}