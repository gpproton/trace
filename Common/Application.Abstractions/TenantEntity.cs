// Copyright (c) 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://trace.ng/licenses/license-1-0
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

using Axolotl.EFCore.Base;
using Axolotl.EFCore.Interfaces;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions.Interfaces;

namespace Trace.Application.Abstractions;

[Index(nameof(TenantId))]
public abstract class TenantEntity<TKey> : AuditableEntity<TKey>, ITenantEntity
    where TKey : notnull {
    [GraphQLIgnore]
    public Guid? TenantId { get; set; }
}