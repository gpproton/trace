// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace Source Available License 1.0;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Trace.Common.Domain.Modules.Identity.Entities;
using Trace.Common.Domain.Permission;

namespace Trace.Common.Domain.Interfaces;

public interface IAccountEntity
{
    public Identity Identity { get; set; }
    public RoleLevel DefaultRole { get; set; }
    public AccountRoleEntity? Role { get; set; }
}