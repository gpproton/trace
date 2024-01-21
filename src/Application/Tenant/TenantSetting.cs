﻿// Copyright (c) 2023 - 2024 drolx Solutions
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
// Created At: Saturday, 13th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Sat Jan 13 2024

using Axolotl.EFCore.Base;
using Trace.Application.Abstractions;
using Trace.Application.Core;

namespace Trace.Application.Tenant;

public class TenantSetting : BaseEntity<Guid> {
    public Tenant? Tenant { get; set; }
    public Guid? TenantId { get; set; }
    public required ProfileOption Option { get; set; }
    public required MapOption Map { get; set; }
}
