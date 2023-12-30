// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Trace.ServiceDefaults;

public static class Nodes {
    public const string GroupName = "Trace";

    public static readonly IReadOnlyList<string> All = new List<string> {
        Core,
        Integration,
        Routing
    };

    // Services
    public const string Gateway = nameof(Gateway);
    public const string Client = nameof(Client);
    public const string Integration = nameof(Integration);
    public const string Core = nameof(Core);
    public const string Routing = nameof(Routing);
    public const string Manager = nameof(Manager);
    public const string Worker = nameof(Worker);
}