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
// Created At: Monday, 26th Feb 2024
// Modified By: Godwin peter .O
// Modified At: Mon Mar 18 2024

using System.Reflection;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Trace.ServiceDefaults.Extensions;

public static class GraphqlHelperExtension {
    private static IEnumerable<Type> DiscoverObjectExtensions(this Assembly assembly) {
        return assembly.GetTypes()
        .Where(x => x.CustomAttributes
        .Any(y => y.AttributeType == typeof(ExtendObjectTypeAttribute)));
    }

    public static IRequestExecutorBuilder RegisterObjectExtensions(this IRequestExecutorBuilder requestExecutorBuilder,
        Assembly assembly) {
        var extensionTypes = DiscoverObjectExtensions(assembly);

        foreach (var type in extensionTypes)
            requestExecutorBuilder.AddTypeExtension(type);

        return requestExecutorBuilder;
    }
}