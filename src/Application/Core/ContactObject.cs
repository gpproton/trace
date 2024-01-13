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

using Trace.Application.Core.Interfaces;

namespace Trace.Application.Core;

public class ContactObject : IAddressEntity {
    public DateOnly? BirthDate { get; set; }
    public int NumberOfChildren { get; set; }
    public string? NextKinName { get; set; }
    public string? NextKinPhone { get; set; }
    public string? NextKinEmail { get; set; }
    public string? GuarantorName { get; set; }
    public string? GuarantorPhone { get; set; }
    public string? GuarantorEmail { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressCounty { get; set; }
    public string? AddressState { get; set; }
    public string? AddressZip { get; set; }
    public string? AddressCountry { get; set; }
    public string? HomePhone { get; set; }
    public string? MobilePhone { get; set; }
    public Guid Id { get; set; }
}