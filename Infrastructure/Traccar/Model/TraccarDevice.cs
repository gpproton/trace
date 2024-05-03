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
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Tue Jan 02 2024

using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Trace.Infrastructure.Traccar.Model;

public class TraccarDevice {
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("attributes")]
    public JsonObject? Attributes { get; set; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("calendarId")]
    public long CalendarId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("uniqueId")]
    public string UniqueId { get; set; } = null!;

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("lastUpdate")]
    public DateTimeOffset? LastUpdate { get; set; }

    [JsonPropertyName("positionId")]
    public long PositionId { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("contact")]
    public string? Contact { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("expirationTime")]
    public DateTimeOffset? ExpirationTime { get; set; }
}