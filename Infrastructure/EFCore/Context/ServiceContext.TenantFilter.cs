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
// Created Date: 2024-1-17 2:22
// Modified By: Godwin peter .O
// Last Modified: 2024-1-17 2:22

using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Account;

namespace Trace.Infrastructure.EFCore.Context;

public sealed partial class ServiceContext {
    private static void RegisterTenantFilter(ModelBuilder modelBuilder) {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            if (typeof(ITenantEntity).IsAssignableFrom(entityType.ClrType))
                AddTenantQueryFilter(entityType);
    }
    private static void AddTenantQueryFilter(IMutableEntityType entityData) {
        var methodToCall = typeof(ServiceContext)
            .GetMethod(nameof(GetTenantFilter), BindingFlags.NonPublic | BindingFlags.Instance)
            ?.MakeGenericMethod(entityData.ClrType);
        var filter = methodToCall?.Invoke(null, []);
        entityData.SetQueryFilter((LambdaExpression)filter!);
        entityData.AddIndex(entityData. FindProperty(nameof(ITenantEntity.TenantId))!);
    }

    private Expression<Func<TEntity, bool>> GetTenantFilter<TEntity>()
        where TEntity : ITenantEntity {
        Expression<Func<TEntity, bool>> filter = x => x.TenantId == TenantId;
        return filter;
    }
}