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
// Created At: Tuesday, 2nd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Tue Jan 02 2024

using Grpc.Core;

namespace Trace.Service.Integration.Protocol.Services;

public class ProtocolService(ILogger<ProtocolService> logger) : Protocol.ProtocolBase {

    public override Task<AckResponse> Ping(Google.Protobuf.WellKnownTypes.Empty empty, ServerCallContext context) {
        logger.LogInformation("Received ping");
        return Task.FromResult(new AckResponse {
            Completed = true
        });
    }

    public override Task<AckResponse> GetSession(AuthMessage request, ServerCallContext context) {
        logger.LogInformation("Requested for session");
        return Task.FromResult(new AckResponse {
            Completed = true
        });
    }

    public override Task<PositionResponse> SendPosition(PositionMessage request, ServerCallContext context) {
        logger.LogInformation("Received position message");
        return Task.FromResult(new PositionResponse {
            Status = ResponseCode.Ok
        });
    }
}