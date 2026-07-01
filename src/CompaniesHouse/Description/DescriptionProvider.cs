using System.Text.Json;
using System.Text.RegularExpressions;

namespace CompaniesHouse.Description
{
    public class DescriptionProvider
    {
        private static readonly Regex _pattern = new Regex(@"({[a-zA-Z0-9.-_]*})");

        public static string GetDescription(string format, JsonElement? values)
        {
            if (values is { ValueKind: JsonValueKind.Object } element)
            {
                foreach (Match match in _pattern.Matches(format))
                {
                    var placeHolder = match.Value;
                    var variableName = placeHolder.TrimStart('{').TrimEnd('}');
                    var variableValue = SelectToken(element, variableName);

                    if (variableValue is { ValueKind: JsonValueKind.String })
                    {
                        format = format.Replace(placeHolder, variableValue.Value.GetString());
                    }
                }
            }

            return format;
        }

        private static JsonElement? SelectToken(JsonElement root, string path)
        {
            var current = root;

            foreach (var segment in path.Split('.'))
            {
                if (current.ValueKind != JsonValueKind.Object || !current.TryGetProperty(segment, out current))
                {
                    return null;
                }
            }

            return current;
        }
    }
}

