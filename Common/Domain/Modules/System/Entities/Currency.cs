// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace Source Available License 1.0;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Axolotl.EFCore.Base;

namespace Trace.Common.Domain.Modules.System.Entities;

public class Currency : BaseEntity<Guid>, ITypedEntity
{
    public bool Default { get; set; }
    public string Symbol { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Country { get; set; } = String.Empty;
    public string? Description { get; set; }
}