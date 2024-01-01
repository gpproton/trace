// Copyright 2023 - 2024 Godwin peter .O (me@godwin.dev)
//
// Licensed under the Business Source License 1.1 and Trace License;
// you may not use this file except in compliance with the License.
//
//     https://mariadb.com/bsl11
//     https://trace.ng/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Trace.Application;

public static class DependencyInjection {
    public static IServiceCollection RegisterService(this IServiceCollection services, Assembly assembly) {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
