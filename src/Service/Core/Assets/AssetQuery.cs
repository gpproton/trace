// Copyright 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace License;
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
// Created Date: 2024-1-13 19:8
// Modified By: Godwin peter .O
// Last Modified: 2024-1-13 19:8

using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Trace.Application.Abstractions;
using Trace.Application.Asset;

namespace Trace.Service.Core.Assets;

[ExtendObjectType(typeof(QueryRoot))]
public class AssetQuery {
    [UsePaging]
    [UseFiltering]
    [GraphQLDescription("Query assets")]
     public IQueryable<Asset> GetAssets([Service(ServiceKind.Synchronized)] IAssetRepository assetRepository) => assetRepository.GetAll();
}