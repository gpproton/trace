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
// Modified At: Mon Jan 15 2024

using Microsoft.Extensions.DependencyInjection;
using Trace.Common.PipeHandlers.Interfaces;

namespace Trace.Common.PipeHandlers;

public abstract class Pipeline<TClass, TInput>(IServiceScopeFactory factory) : IPipeline<TClass, TInput> where TClass : class {
    private readonly List<IAsyncHandler<TInput>> _handlers = [];
    private readonly IServiceProvider _serviceProvider = factory.CreateScope().ServiceProvider;

    public Pipeline<TClass, TInput> Add(IAsyncHandler<TInput> handler) {
        if (handler == null) throw new ArgumentNullException(nameof(handler));

        _handlers.Add(handler);
        return this;
    }

    public Pipeline<TClass, TInput> Add<TFilter>() where TFilter : IAsyncHandler<TInput> {
        var service = _serviceProvider.GetRequiredService<TFilter>() ??
                      throw new ArgumentNullException(nameof(_serviceProvider));
        return Add(service);
    }

    public async Task<TInput> ProcessAsync(TInput input, CancellationToken cancellationToken = default) {
        TInput currentValue = input;
        foreach (var handler in _handlers) {
            currentValue = await handler.ProcessAsync(currentValue, cancellationToken);
        }

        return currentValue;
    }

    public static void RegisterHandlers(IServiceCollection services, params Type[] handlers) {
        services.AddScoped(typeof(TClass));
        foreach (var handler in handlers) {
            services.AddScoped(handler);
        }
    }
}