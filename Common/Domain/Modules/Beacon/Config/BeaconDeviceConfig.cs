// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trace.Common.Domain.Modules.Asset.Entities;
using Trace.Common.Domain.Modules.Beacon.Entities;

namespace Trace.Common.Domain.Modules.Beacon.Config;

public class BeaconDeviceConfig : IEntityTypeConfiguration<BeaconDevice> {
    public void Configure(EntityTypeBuilder<BeaconDevice> builder) {
        builder.Property(b => b.Id)
        .IsRequired()
        .HasMaxLength(256);

        // builder.HasOne(b => b.Type)
        // .WithOne()
        // .HasForeignKey<AssetType>(k => k.Id)
        // .IsRequired(false);

    }
}