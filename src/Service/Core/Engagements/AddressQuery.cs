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
// Created At: Thursday, 18th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 18 2024

using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Trace.Application;
using Trace.Application.Abstractions;
using Trace.Application.Engagement;
using Trace.Application.Engagement.Repositories;

namespace Trace.Service.Core.Engagements;

[ExtendObjectType(typeof(QueryRoot))]
[GraphQLDescription("Query address for a contact")]
public class AddressQuery(IContactRepository repository) {
    public async Task<List<Address>> GetContactAddresses(Guid id) {
        var query = await repository.GetQueryable().Include(b => b.Addresses).SingleOrDefaultAsync(x => x.Id == id);

        return [.. query?.Addresses];
    }
}