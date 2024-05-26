// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace Source Available License 1.0;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Trace.Common.Domain.Modules.Asset.Entities;

namespace Trace.Common.Domain.Modules.Asset.Shared;

public abstract class AssetEntity : TaggedEntity<Guid>
{
    public string SerialNumber { get; set; } = null!;

    public string Barcode { get; set; } = String.Empty;

    public string UniqueId { get; set; } = null!;

    public string Color { get; set; } = String.Empty;

    public int? YearManufactured { get; set; }

    public DateTimeOffset? Deployed { get; set; }

    public DateTimeOffset? Decommissioned { get; set; }

    // public string? Images { get; set; }

    // public Guid? ManufacturerId { get; set; }

    // public Guid? StockId { get; set; }

    public virtual AssetCategory? Category { get; set; }

    public Guid CategoryId { get; set; }
}