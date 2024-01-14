// Copyright (c) 2023 - 2024 drolx Solutions
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
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Mon Jan 01 2024

namespace Trace.ServiceDefaults;

public static class Nodes {
    public const string GroupName = "Trace";

    public static readonly IReadOnlyList<string> All = [
        Core,
        Integration,
        Navigation
    ];

    // Services
    public const string Gateway = nameof(Gateway);
    public const string Client = nameof(Client);
    public const string Integration = nameof(Integration);
    public const string Core = nameof(Core);
    public const string Navigation = nameof(Navigation);
    public const string Manager = nameof(Manager);
}