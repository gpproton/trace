// Copyright 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0;
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
// Created Date: 2024-1-15 19:31
// Modified By: Godwin peter .O
// Last Modified: 2024-1-15 19:31

using Microsoft.AspNetCore.Builder;
using Trace.Application.Device;
using Trace.Application.Protocol;
using Trace.Common.Warehouse;
using Trace.Common.Warehouse.Constants;

namespace Trace.Infrastructure.Cassandra;

public static class CassandraServiceCollection
{
    public static WebApplicationBuilder RegisterCassandraInfrastructure(this WebApplicationBuilder builder)
    {
        const string keyspace = CanssandraConst.Keyspace;
        builder.AddCassandra([
            Position.GetConfig(keyspace),
        ]);

        return builder;
    }
}