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
// Modified At: Thu Jan 18 2024

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Redis.OM.Modeling;
using Trace.Application.Abstractions;
using Trace.Application.Core.Enums;

namespace Trace.Application.Device;

[Index(nameof(UniqueId), IsUnique = true)]
[Index(nameof(PositionId))]
[Index(nameof(LastUpdate))]
[Index(nameof(Status))]
[Document(StorageType = StorageType.Hash, Prefixes = [nameof(Device)])]
public sealed class Device : AssetEntity {
    [Indexed]
    [MaxLength(64)]
    public required string UniqueId { get; set; }
    [Indexed]
    public Guid? PositionId { get; set; }
    [Indexed]
    public DateTimeOffset? LastUpdate { get; set; }
    public DateTimeOffset? LastMoved { get; set; }
    [Indexed]
    [MaxLength(15)]
    public string? Phone { get; set; }
    [Indexed]
    public DeviceStatus Status { get; set; } = DeviceStatus.Offline;
    public int SpeedLimit { get; set; }
    public DateTimeOffset? Expiry { get; set; }
}