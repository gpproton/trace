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
using Microsoft.EntityFrameworkCore;
using Redis.OM.Modeling;
using Trace.Application.Abstractions;

namespace Trace.Application.Tenant;

[Index(nameof(Domain))]
[Index(nameof(Expiry))]
[Document(StorageType = StorageType.Hash, Prefixes = [nameof(TenantDomain)])]
public class TenantDomain : TenantEntity<Guid> {
    public Tenant? Tenant { get; set; }
    [Indexed]
    [MaxLength(256)]
    public string Domain { get; set; } = null!;
    [Indexed]
    [MaxLength(256)]
    public string? Registrar { get; set; }
    [Indexed]
    public bool Active { get; set; }
    [Indexed]
    public DateTimeOffset? Expiry { get; set; }
}