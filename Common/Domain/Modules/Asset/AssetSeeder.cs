// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Trace.Common.Domain.Context;
using Trace.Common.Domain.Modules.Asset.Entities;

namespace Trace.Common.Domain.Modules.Asset;

public class AssetSeeder : DefaultSeeder {
    public override void Run() {
        var assetType = Load(new List<AssetCategory> {
            new AssetCategory { Id = Guid.NewGuid(), Name = "Type 00"
            }
        });

        Load(new List<Entities.Asset> {
            new Entities.Asset {
                Id = Guid.NewGuid(),
                Name = "Asset-001",
                CategoryId = assetType[0].Id,
                SerialNumber = "12345",
                UniqueId = "12345"
            }
        });
    }
}