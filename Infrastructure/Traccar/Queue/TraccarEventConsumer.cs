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
// Modified At: Mon Jan 15 2024

using Microsoft.Extensions.Logging;
using Trace.Common.Queueing.Interfaces;
using Trace.Infrastructure.Traccar.Model;

namespace Trace.Infrastructure.Traccar.Queue;

public class TraccarEventConsumer(ILogger<TraccarEventConsumer> logger) : IQueueConsumer<TraccarEventObject> {
    public Task ConsumeAsync(TraccarEventObject message) {
        logger.LogInformation($"Event Type: {message.Event.Type}; Device ID: {message.Device?.Name}; Event Id: {message.Event.Id}");

        return Task.CompletedTask;
    }
}