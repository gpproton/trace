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
// Created At: Friday, 12th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using Axolotl.EFCore.Base;

namespace Trace.Application.Abstractions;

public abstract class ExtendedEntity: CoreEntity {
    public Dictionary<string, object> Attributes;
    protected ExtendedEntity() {
        Attributes = [];
    }

    public bool HasAttribute(string key) => Attributes.ContainsKey(key);
    public Dictionary<string, object> GetAttributes() => Attributes;
    public void SetAttributes(Dictionary<string, object> attributes) => Attributes = attributes;
    public void Set(string key, bool value) => Attributes.TryAdd(key, value);
    public void Set(string key, byte value) => Attributes.TryAdd(key, value);
    public void Set(string key, int value) => Attributes.TryAdd(key, value);
    public void Set(string key, decimal value) => Attributes.TryAdd(key, value);
    public void Set(string key, double value) => Attributes.TryAdd(key, value);
    public void Set(string key, float value) => Attributes.TryAdd(key, value);
    public void Set(string key, string value) => Attributes.TryAdd(key, value);
    public void Set<TKey>(string key, TKey value) where TKey : notnull => Attributes.TryAdd(key, value);

    public TValue? GetAny<TValue>(string key) {
        Attributes.TryGetValue(key, out var value);
        return (TValue)value!;
    }

    public string GetString(string key) {
        Attributes.TryGetValue(key, out var value);
        return (string)value!;
    }

    public bool GetBoolean(string key) {
        Attributes.TryGetValue(key, out var value);
        return value is true;
    }

    public decimal GetDecimal(string key) {
        Attributes.TryGetValue(key, out var value);
        if (value is decimal d) return d;
        return 0;
    }

    public double GetDouble(string key) {
        Attributes.TryGetValue(key, out var value);
        if (value is double d) return d;
        return 0.0;
    }

    public int GetInteger(string key) {
        Attributes.TryGetValue(key, out var value);
        if (value is int i) return i;
        return 0;
    }

    public float GetFloat(string key) {
        Attributes.TryGetValue(key, out var value);
        if (value is float i) return i;
        return 0;
    }
}