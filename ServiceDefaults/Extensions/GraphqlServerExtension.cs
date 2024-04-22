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
// Created At: Monday, 26th Feb 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

using HotChocolate;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Trace.ServiceDefaults.Extensions;

public static class GraphqlServerExtension {
    public static IRequestExecutorBuilder AddGraphqlDefaults(this IRequestExecutorBuilder services, string? name = null) {
        services
        .InitializeOnStartup()
        .AddSorting()
        .AddFiltering()
        .AddProjections()
        .AddType<UploadType>()
        .UseAutomaticPersistedQueryPipeline()
        .AddRedisQueryStorage(sp => sp.GetRequiredService<IConnectionMultiplexer>().GetDatabase())
        .AddApolloTracing()
        .AddMutationConventions(applyToAllMutations: true)
        .AddRedisSubscriptions(sp => sp.GetRequiredService<IConnectionMultiplexer>())
        .SetPagingOptions(new PagingOptions {
            MaxPageSize = 1000,
            DefaultPageSize = 50,
            IncludeTotalCount = true
        });

        // if (name is not null)
        //     services.PublishSchemaDefinition(c => {
        //         c.SetName(name)
        //         .PublishToRedis(Nodes.GroupName,
        //             sp => sp.GetRequiredService<IConnectionMultiplexer>());
        //     });

        return services;
    }

    public static IRequestExecutorBuilder AddRequestOptions(this IRequestExecutorBuilder services, bool IsDevelopement) {
        services.ModifyRequestOptions(opt => {
            opt.Complexity.ApplyDefaults = true;
            opt.Complexity.DefaultComplexity = 1;
            opt.Complexity.DefaultResolverComplexity = 5;
            opt.IncludeExceptionDetails = IsDevelopement;
        });

        return services;
    }
}