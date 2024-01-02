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
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Tue Jan 02 2024

using System.Text.Json.Serialization;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Infrastructure.Traccar.Model;

public sealed class TraccarEventObject : IQueueMessage {
    [JsonPropertyName("event")]
    public required TraccarEvent Event { get; set; }

    [JsonPropertyName("device")]
    public TraccarDevice Device { get; set; } = default!;

    [JsonPropertyName("position")]
    public TraccarPosition? Position { get; set; }
}
