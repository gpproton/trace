// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Trace.Common.Domain.Permission;

namespace Trace.Common.Domain.Modules.Asset;

public class AssetPermission : IPermission {
    private const string Id = "asset";
    private const RoleLevel Role = RoleLevel.Default;
    private const Module DefaultModule = Module.Asset;
    public IEnumerable<PermissionItem> Result() => new List<PermissionItem> {
        new PermissionItem(DefaultModule, $"{Id}.overview", Role, new []{ true, false, false, false })
    };
}