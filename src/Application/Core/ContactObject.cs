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
// Created At: Wednesday, 3rd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 04 2024

using System.ComponentModel.DataAnnotations.Schema;
using Trace.Application.Core.Interfaces;

namespace Trace.Application.Core;

[ComplexType]
public class ContactObject : IContactEntity {
    public DateOnly? BirthDate { get; set; }
    public bool Married { get; set; }
    public int ChildrenCount { get; set; }
    public string? KinName { get; set; }
    public string? KinPhone { get; set; }
    public string? KinEmail { get; set; }
    public string? GuarantorName { get; set; }
    public string? GuarantorPhone { get; set; }
    public string? GuarantorEmail { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? City { get; set; }
    public string? County { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? HomePhone { get; set; }
    public string? Phone { get; set; }
}