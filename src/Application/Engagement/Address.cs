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

using System.ComponentModel.DataAnnotations;
using Trace.Application.Abstractions;
using Trace.Application.Core.Interfaces;
using Trace.Application.Engagement.Enums;

namespace Trace.Application.Engagement;

public class Address : TenantEntity<Guid>, IContactEntity {
    public AddressVariant Type { get; set; } = AddressVariant.Contact;
    [MaxLength(512)]
    public string? Line1 { get; set; }
    [MaxLength(512)]
    public string? Line2 { get; set; }
    [MaxLength(50)]
    public string? City { get; set; }
    [MaxLength(50)]
    public string? County { get; set; }
    [MaxLength(50)]
    public string? State { get; set; }
    [MaxLength(10)]
    public string? Zip { get; set; }
    [MaxLength(25)]
    public string? Country { get; set; }
    [MaxLength(12)]
    public string? HomePhone { get; set; }
    [MaxLength(12)]
    public string? Phone { get; set; }
}
