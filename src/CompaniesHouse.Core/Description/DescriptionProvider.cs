using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.Core.Description
{
    public class DescriptionProvider
    {
        private static readonly Regex _pattern = new Regex(@"({[a-zA-Z0-9.-_]*})");

        public static string GetDescription(string format, JObject values)
        {
            if (values != null)
            {
                foreach (Match match in _pattern.Matches(format))
                {
                    var placeHolder = match.Value;
                    var variableName = placeHolder.TrimStart('{').TrimEnd('}');
                    var variableValue = values.SelectToken(variableName);

                    if (variableValue != null)
                    {
                        format = format.Replace(placeHolder, variableValue.Value<string>());
                    }
                }
            }

            return format;
        }
    }
}
