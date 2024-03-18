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
// Created At: Sunday, 14th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Sun Jan 14 2024

using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trace.Application.Device.Types;
using Trace.Application.Engagement.Types;
using Trace.Application.Tags.Types;

namespace Trace.Infrastructure;

public static class ApplicationTypes {
    public static IRequestExecutorBuilder AddApplicationTypes(this IRequestExecutorBuilder services) {
        // Engagement types
        services.AddType<ContactType>();
        services.AddType<OpportunityType>();
        services.AddType<LeadType>();
        services.AddType<AddressType>();
        // Tag types
        services.AddType<TagsType>();
        services.AddType<TagMembersType>();
        // Device types
        services.AddType<DeviceType>();
        services.AddType<DeviceCommandType>();

        return services;
    }
}
