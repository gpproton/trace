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

namespace Trace.Application.Abstractions;

public abstract class TaggedEntity<T> : Axolotl.EFCore.Base.AuditableEntity<T>, ITaggedEntity<T> where T : notnull {
    public ICollection<Tags.Tags>? Tags { get; set; }
    public T? TagId { get; set; }
    public T? TenantId { get; set; }
}