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
// Modified At: Fri Jan 12 2024

using Axolotl.EFCore.Base;
using Redis.OM.Modeling;
using Trace.Application.Core.Enums;

namespace Trace.Application.Device;

[Document(StorageType = StorageType.Hash, Prefixes = [nameof(Device)])]
public sealed class Device : BaseEntity<Guid> {
    [Indexed]
    public required string UniqueId { get; set; }
    [Indexed]
    public Guid? PositionId { get; set; }
    [Indexed]
    public DateTimeOffset? LastUpdate { get; set; }
    public DateTimeOffset? LastMoved { get; set; }
    [Indexed]
    public string Phone { get; set; } = string.Empty;
    [Indexed]
    public DeviceStatus Status { get; set; }
    public int SpeedLimit { get; set; }
    public DateTimeOffset? Expiry { get; set; }
}