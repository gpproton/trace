// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
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
// Created At: Wednesday, 3rd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 04 2024

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Abstractions;
using Trace.Application.Abstractions.Interfaces;
using Trace.Application.Core;
using Trace.Application.Core.Interfaces;
using Trace.Application.Engagement.Enums;

namespace Trace.Application.Engagement;

[Index(nameof(TenantId), nameof(Email), IsUnique = true)]
public class Contact : TaggedEntity<Guid>, ITenantEntity, IPersonEntity {
    public ContactVariant Type { get; set; } = ContactVariant.Contact;
    public ContactRelationVariant RelationType { get; set; } = ContactRelationVariant.None;
    [MaxLength(256)]
    public required string FullName { get; set; }
    [MaxLength(256)]
    public string? JobPosition { get; set; }
    public bool Active { get; set; }
    [MaxLength(15)]
    public required string Mobile { get; set; }
    [MaxLength(15)]
    public string? Phone { get; set; }
    [MaxLength(256)]
    public required string Email { get; set; }
    [MaxLength(512)]
    public string? Website { get; set; }
    public bool Married { get; set; }
    public DateOnly? BirthDate { get; set; }
    [MaxLength(1024)]
    public string? Notes { get; set; }
    public Contact? Company { get; set; }
    public ICollection<Address> Addresses { get; set; } = [];
    public ICollection<Contact> Relations { get; set; } = [];
    public Guid? TenantId { get; set; }
}