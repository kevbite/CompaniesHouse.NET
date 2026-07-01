using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Shouldly;

namespace CompaniesHouse.Tests
{
    /// <summary>
    /// A small, dependency-free replacement for FluentAssertions' <c>BeEquivalentTo</c>.
    /// Recursively compares public properties of two object graphs, with built-in bridging
    /// between production enum/value-type values and the raw wire strings used by the test
    /// <c>ResourceBuilders</c> fixtures (matched via each enum member's <see cref="EnumMemberAttribute"/>).
    /// This removes the need for the old FluentAssertions <c>IEquivalencyStep</c>/<c>MapProviders</c> machinery.
    /// </summary>
    public static class EquivalencyAssertionExtensions
    {
        public static void ShouldBeEquivalentTo<T>(this T actual, T expected, params string[] excludingPropertyNames)
        {
            var differences = new List<string>();
            Compare(actual, expected, typeof(T).Name, excludingPropertyNames ?? Array.Empty<string>(), differences);

            if (differences.Count > 0)
            {
                throw new ShouldAssertException(
                    $"Objects were not equivalent:{Environment.NewLine}{string.Join(Environment.NewLine, differences)}");
            }
        }

        private static void Compare(object actual, object expected, string path, string[] excluding, List<string> differences)
        {
            if (ReferenceEquals(actual, expected))
            {
                return;
            }

            if (actual is null || expected is null)
            {
                differences.Add($"{path}: expected <{Describe(expected)}> but was <{Describe(actual)}>");
                return;
            }

            // Enum/string-backed-value-type <-> raw wire string bridging (either direction).
            if (actual is Enum actualEnum && expected is string expectedString)
            {
                var actualWireValue = GetEnumMemberValue(actualEnum);
                if (actualWireValue != expectedString)
                {
                    differences.Add($"{path}: expected <{expectedString}> but was <{actualWireValue}>");
                }

                return;
            }

            if (expected is Enum expectedEnum && actual is string actualString)
            {
                var expectedWireValue = GetEnumMemberValue(expectedEnum);
                if (expectedWireValue != actualString)
                {
                    differences.Add($"{path}: expected <{expectedWireValue}> but was <{actualString}>");
                }

                return;
            }

            if (TryGetStringBackedValue(actual, out var actualRawValueFromValueType) && expected is string expectedRawValue)
            {
                if (actualRawValueFromValueType != expectedRawValue)
                {
                    differences.Add($"{path}: expected <{expectedRawValue}> but was <{actualRawValueFromValueType}>");
                }

                return;
            }

            if (TryGetStringBackedValue(expected, out var expectedRawValueFromValueType) && actual is string actualRawValue)
            {
                if (expectedRawValueFromValueType != actualRawValue)
                {
                    differences.Add($"{path}: expected <{expectedRawValueFromValueType}> but was <{actualRawValue}>");
                }

                return;
            }

            // Array/collection of enums compared against a single raw wire string:
            // replicates the old "does this collection contain the mapped value" behaviour.
            if (actual is IEnumerable actualContainer && actual is not string && expected is string containsExpected)
            {
                var found = actualContainer.Cast<object>().Any(item => ValuesEqual(item, containsExpected));
                if (!found)
                {
                    differences.Add($"{path}: expected collection to contain <{containsExpected}> but was <{Describe(actual)}>");
                }

                return;
            }

            var actualType = actual.GetType();

            if (actualType.IsEnum || actualType.IsPrimitive || actual is string || actual is DateTime
                || actual is DateTimeOffset || actual is decimal || actual is Guid || actual is TimeSpan)
            {
                if (!Equals(actual, expected))
                {
                    differences.Add($"{path}: expected <{Describe(expected)}> but was <{Describe(actual)}>");
                }

                return;
            }

            if (actual is IEnumerable actualEnumerable && expected is IEnumerable expectedEnumerable)
            {
                var actualList = actualEnumerable.Cast<object>().ToList();
                var expectedList = expectedEnumerable.Cast<object>().ToList();

                if (actualList.Count != expectedList.Count)
                {
                    differences.Add($"{path}: expected {expectedList.Count} item(s) but found {actualList.Count}");
                    return;
                }

                for (var i = 0; i < actualList.Count; i++)
                {
                    Compare(actualList[i], expectedList[i], $"{path}[{i}]", excluding, differences);
                }

                return;
            }

            // Complex object: recurse over public instance properties.
            foreach (var property in actualType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.GetIndexParameters().Length > 0 || excluding.Contains(property.Name))
                {
                    continue;
                }

                var expectedProperty = expected.GetType().GetProperty(property.Name);
                if (expectedProperty is null)
                {
                    continue;
                }

                var actualValue = property.GetValue(actual);
                var expectedValue = expectedProperty.GetValue(expected);

                Compare(actualValue, expectedValue, $"{path}.{property.Name}", excluding, differences);
            }
        }

        private static bool ValuesEqual(object actual, object expected)
        {
            if (actual is Enum actualEnum && expected is string expectedString)
            {
                return GetEnumMemberValue(actualEnum) == expectedString;
            }

            if (TryGetStringBackedValue(actual, out var actualRawValueFromValueType) && expected is string expectedRawValue)
            {
                return actualRawValueFromValueType == expectedRawValue;
            }

            return Equals(actual, expected);
        }

        private static string Describe(object value) => value?.ToString() ?? "null";

        private static string GetEnumMemberValue(Enum enumValue)
        {
            var type = enumValue.GetType();
            var info = type.GetField(enumValue.ToString());
            var enumMember = (EnumMemberAttribute[])info?.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            return enumMember is { Length: > 0 } ? enumMember[0].Value : enumValue.ToString();
        }

        private static bool TryGetStringBackedValue(object value, out string rawValue)
        {
            rawValue = string.Empty;

            if (value is null || value is string || value is Enum)
            {
                return false;
            }

            var valueProperty = value.GetType().GetProperty("Value");
            if (valueProperty?.PropertyType != typeof(string))
            {
                return false;
            }

            rawValue = (string?)valueProperty.GetValue(value) ?? string.Empty;
            return true;
        }
    }
}
