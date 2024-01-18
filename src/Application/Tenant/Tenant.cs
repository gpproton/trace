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
using Axolotl.EFCore.Base;
using Microsoft.EntityFrameworkCore;
using Redis.OM.Modeling;
using Trace.Application.Core.Enums;
using Trace.Application.Engagement;

namespace Trace.Application.Tenant;

[Index(nameof(Name))]
[Index(nameof(TenantSettingId))]
[Document(StorageType = StorageType.Hash, Prefixes = [nameof(Tenant)])]
public class Tenant : BaseEntity<Guid> {
    public Contact? Contact { get; set; }
    [Indexed]
    public Guid? Token { get; set; }
    [Indexed]
    public bool Active { get; set; }
    [Indexed]
    [MaxLength(256)]
    public string Name { get; set; } = null!;
    [Indexed]
    public TenantType Type { get; set; } = TenantType.Individual;
    [Indexed]
    [MaxLength(1024)]
    public string? Logo { get; set; }
    [Indexed]
    public Guid? TenantSettingId { get; set; }
    public ICollection<TenantDomains>? Domains { get; set; }
}