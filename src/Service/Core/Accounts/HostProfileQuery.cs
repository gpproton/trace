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
// Created At: Friday, 12th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using HotChocolate.Types;
using Trace.Application;
using Trace.Application.Abstractions;
using Trace.Application.Tenant;

namespace Trace.Service.Core.Accounts;

[ExtendObjectType(typeof(QueryRoot))]
public class HostProfileQuery(ITenantRepository tenantRepository) {
    public async Task<Tenant?> GetHostProfile(Guid id) => await tenantRepository.GetByIdAsync(id);
}
