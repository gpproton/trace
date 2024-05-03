// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
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
// Created At: Friday, 12th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using Axolotl.EFCore.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Account;

namespace Trace.Infrastructure.EFCore.Context;

public sealed partial class ServiceContext {
    private void AuditableOnBeforeSaving() {
        var entries = ChangeTracker.Entries<IAuditableEntity>().ToList();
        var utcNow = DateTimeOffset.UtcNow;

        foreach (var entry in entries) {
            if (entry.Entity is { } trackable) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.Property("UpdatedAt").IsModified = false;
                        entry.Property("DeletedAt").IsModified = false;
                        trackable.CreatedAt = utcNow;
                        break;
                    case EntityState.Modified:
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("DeletedAt").IsModified = false;
                        trackable.UpdatedAt = utcNow;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        bool _ = entry.References.All(e => e.IsModified = true);
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("UpdatedAt").IsModified = false;
                        trackable.DeletedAt = utcNow;
                        break;
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    default:
                        break;
                }
            }
        }
    }

    private void TenantOnBeforeSaving() {
        foreach (var entry in ChangeTracker.Entries<ITenantEntity>().ToList()) {
            switch (entry.State) {
                case EntityState.Added:
                case EntityState.Modified:
                    entry.Entity.TenantId = TenantId;
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                default:
                    break;
            }
        }
    }
}