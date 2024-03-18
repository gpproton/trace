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
// Created Date: 2024-1-22 23:6
// Modified By: Godwin peter .O
// Last Modified: 2024-1-22 23:6

using System.ComponentModel.DataAnnotations;
using Axolotl.EFCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Redis.OM.Modeling;
using Trace.Application.Protocol;

namespace Trace.Application.Device;

[Index(nameof(DeviceId), IsUnique = true)]
[Document(StorageType = StorageType.Hash, Prefixes = [nameof(DevicePosition)])]
public class DevicePosition : BasePosition, IAggregateRoot, IAuditableEntity {
    [Key]
    [Indexed]
    [RedisIdField]
    public Guid DeviceId { get; set; }

    public Device Device { get; set; } = null!;
    [Indexed]
    public DateTimeOffset CreatedAt { get; set; }
    [Indexed]
    public DateTimeOffset? UpdatedAt { get; set; }
    [Indexed]
    public DateTimeOffset? DeletedAt { get; set; }
}