// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace Source Available License 1.0;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Trace.Common.Domain.Modules.Identity.Entities;

public class IdentityProfile : TenantEntity<Guid>, IAddressEntity
{
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
}