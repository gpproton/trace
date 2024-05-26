// Copyright 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0;
// you may not use this file except in compliance with the License.
//     https://mariadb.com/bsl11
//     https://trace.ng/license
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created Date: 2024-1-13 18:56
// Modified By: Godwin peter .O
// Last Modified: 2024-1-13 18:56

using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Trace.Application;
using Trace.Application.Trailer;

namespace Trace.Service.Core.Trailers;

[ExtendObjectType(typeof(QueryRoot))]
public class TrailerQuery(ITrailerRepository trailerRepository)
{
    [UsePaging]
    [UseFiltering]
    [GraphQLDescription("Query Trailers")]
    public IQueryable<Trailer> GetTrailers() => trailerRepository.Query();
}