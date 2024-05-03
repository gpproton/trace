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
// Created At: Wednesday, 3rd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Wed Jan 03 2024

using Axolotl.EFCore.Interfaces;
using Cassandra.Mapping;
using Trace.Application.Abstractions;
using Trace.Application.Abstractions.Enums;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Core.Interfaces;

namespace Trace.Application.Events;

public class Events : ExtendedEntity, IHasKey<Guid>, ITenantEntity {
    public Guid Id { get; set; }
    public Guid? TenantId { get; set; }
    public DateTimeOffset Time { get; set; }
    public DateTimeOffset ServerTime { get; set; }
    public EventTypes Type { get; set; }
    public Guid? DeviceId { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? LocationId { get; set; }
    public static Map<Events> GetConfig(string keyspace) {
        return new Map<Events>()
            .KeyspaceName(keyspace)
            .TableName("events")
            .PartitionKey(x => x.Id)
            .Column(x => x.Id, x => x.WithName("id"))
            .Column(x => x.TenantId, x => x.WithName("tenant_id"))
            .Column(x => x.Time, x => x.WithName("event_time"))
            .Column(x => x.ServerTime, x => x.WithName("server_time"))
            .Column(x => x.Type, x => x.WithName("event_type"))
            .Column(x => x.DeviceId, x => x.WithName("device_id"))
            .Column(x => x.PositionId, x => x.WithName("position_id"))
            .Column(x => x.LocationId, x => x.WithName("location_id"));
    }
}