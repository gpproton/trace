// Copyright (c) 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0;
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
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Mon Jan 01 2024

namespace Trace.ServiceDefaults;

public static class Nodes
{
    public const string GroupName = "Trace";

    public static IReadOnlyList<string> All => [
        Core,
        Integration,
        Navigation
    ];

    public static string Gateway => nameof(Gateway).ToLower();
    public static string Frontend => nameof(Frontend).ToLower();
    public static string Website => nameof(Website).ToLower();
    public static string Integration => nameof(Integration).ToLower();
    public static string Core => nameof(Core).ToLower();
    public static string Worker => nameof(Worker).ToLower();
    public static string Navigation => nameof(Navigation).ToLower();
    public static string Manager => nameof(Manager).ToLower();
}