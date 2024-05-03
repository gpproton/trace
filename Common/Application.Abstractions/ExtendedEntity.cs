// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
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

namespace Trace.Application.Abstractions;

public abstract class ExtendedEntity {
    private Dictionary<string, object> _attributes = [];
    public string? Attributes;

    // TODO: Use json serializer for persistence
    public bool HasAttribute(string key) => _attributes.ContainsKey(key);
    public Dictionary<string, object> GetAttributes() => _attributes;
    public void SetAttributes(Dictionary<string, object> attributes) => _attributes = attributes;
    public void Set(string key, bool value) => _attributes.TryAdd(key, value);
    public void Set(string key, byte value) => _attributes.TryAdd(key, value);
    public void Set(string key, int value) => _attributes.TryAdd(key, value);
    public void Set(string key, decimal value) => _attributes.TryAdd(key, value);
    public void Set(string key, double value) => _attributes.TryAdd(key, value);
    public void Set(string key, float value) => _attributes.TryAdd(key, value);
    public void Set(string key, string value) => _attributes.TryAdd(key, value);
    public void Set<TKey>(string key, TKey value) where TKey : notnull => _attributes.TryAdd(key, value);

    public TValue? GetAny<TValue>(string key) {
        _attributes.TryGetValue(key, out var value);
        return (TValue)value!;
    }

    public string GetString(string key) {
        _attributes.TryGetValue(key, out var value);
        return (string)value!;
    }

    public bool GetBoolean(string key) {
        _attributes.TryGetValue(key, out var value);
        return value is true;
    }

    public decimal GetDecimal(string key) {
        _attributes.TryGetValue(key, out var value);
        if (value is decimal d) return d;
        return 0;
    }

    public double GetDouble(string key) {
        _attributes.TryGetValue(key, out var value);
        if (value is double d) return d;
        return 0.0;
    }

    public int GetInteger(string key) {
        _attributes.TryGetValue(key, out var value);
        if (value is int i) return i;
        return 0;
    }

    public float GetFloat(string key) {
        _attributes.TryGetValue(key, out var value);
        if (value is float i) return i;
        return 0;
    }
}