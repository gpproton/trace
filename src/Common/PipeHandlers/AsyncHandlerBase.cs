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
// Created At: Monday, 15th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Tue Jan 16 2024

using Trace.Common.PipeHandlers.Interfaces;

namespace Trace.Common.PipeHandlers;

public abstract class AsyncHandlerBase<T> : IAsyncHandler<T> {
    public async Task<T> ProcessAsync(T input, CancellationToken cancellationToken) {
        if (cancellationToken.IsCancellationRequested) {
            return await Task.FromCanceled<T>(cancellationToken);
        }

        return await OnExecuteAsync(input, cancellationToken);
    }

    protected abstract Task<T> OnExecuteAsync(T input, CancellationToken cancellationToken);
}