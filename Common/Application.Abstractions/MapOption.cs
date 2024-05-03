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
// Created Date: 2024-1-13 11:35
// Modified By: Godwin peter .O
// Last Modified: 2024-1-13 11:35

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trace.Application.Abstractions.Interfaces;

namespace Trace.Application.Abstractions;

[ComplexType]
public class MapOption : IMapSettingEntity {
    [MaxLength(128)]
    public string? GoogleApiKey { get; set; }
    [MaxLength(128)]
    public string? BingApiKey { get; set; }
    [MaxLength(128)]
    public string? MapBoxApiKey { get; set; }
    [MaxLength(128)]
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