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
// Created At: Thursday, 11th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 11 2024

using Cassandra;
using Microsoft.Extensions.Logging;
using Trace.Common.Warehouse.Configs;
using Trace.Common.Warehouse.Interfaces;

namespace Trace.Common.Warehouse.Implementation;

public class CassandraProvider : ICassandraProvider, IAsyncDisposable {
    private readonly ILogger<CassandraProvider> _logger;
    private readonly ICluster _cluster;
    private readonly IClusterSession _session;

    public CassandraProvider(ILogger<CassandraProvider> logger, ICluster cluster, CassandraOptions options) {
        _logger = logger;
        _cluster = cluster;
        _session = _cluster.Connect(options.Keyspace);
    }

    public IClusterSession GetSession() => _session;

    public IClusterSession GetSession(string keyspace) {
        try {
            _cluster.Connect(keyspace);
        }
        catch (Exception) {
            _logger.LogCritical("Error connecting to cassandra session");
            throw;
        }

        return _session;
    }

    public async ValueTask DisposeAsync() {
        await _session.ShutdownAsync();
    }
}
