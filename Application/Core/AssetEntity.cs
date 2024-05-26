// Copyright (c) 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://trace.ng/licenses/license-1-0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Thursday, 4th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 04 2024

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions;
using Trace.Application.Asset;

namespace Trace.Application.Core;

[Index(nameof(CategoryId))]
public abstract class AssetEntity : TenantEntity<Guid> {
    [MaxLength(256)]
    public string? Barcode { get; set; }
    [MaxLength(12)]
    public string? Color { get; set; }
    public DateTimeOffset? Deployed { get; set; }
    public DateTimeOffset? Decommissioned { get; set; }
    public AssetCategory? Category { get; set; }
    [MaxLength(256)]
    public Guid? CategoryId { get; set; }
}