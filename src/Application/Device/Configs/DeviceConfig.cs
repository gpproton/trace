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
// Created Date: 2024-1-22 23:42
// Modified By: Godwin peter .O
// Last Modified: 2024-1-22 23:42

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Trace.Application.Device.Configs;

public class DeviceConfig : IEntityTypeConfiguration<Device> {
    public void Configure(EntityTypeBuilder<Device> builder) {
        builder.HasOne<DevicePosition>(e => e.Position)
            .WithOne(e => e.Device)
            .HasForeignKey<Device>(k => k.PositionId)
            .HasPrincipalKey<DevicePosition>(k => k.DeviceId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}
