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
// Created At: Thursday, 11th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Sat Jan 13 2024

using Axolotl.EFCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Abstractions.Permission;
using Trace.Application.Core.Interfaces;

namespace Trace.Application.Account;

[Index(nameof(UserName))]
[Index(nameof(ContactId))]
[Index(nameof(TenantId), nameof(Email), IsUnique = true)]
public class UserAccount : IdentityUser<Guid>, IHasKey<Guid>, ITenantEntity, IAccountEntity, IAggregateRoot {
    public required Engagement.Contact Contact { get; set; }
    public Guid? ContactId { get; set; }
    public RoleLevel DefaultRole { get; set; }
    public Guid? RoleId { get; set; }
    public UserRole? Role { get; set; }
    public Guid? TenantId { get; set; }
    public AccountSetting? AccountSetting { get; set; }
}