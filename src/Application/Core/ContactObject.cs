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
// Created Date: 2024-1-13 17:9
// Modified By: Godwin peter .O
// Last Modified: 2024-1-13 17:9

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trace.Application.Core.Interfaces;

namespace Trace.Application.Core;

[ComplexType]
public class ContactObject : IContactEntity {
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