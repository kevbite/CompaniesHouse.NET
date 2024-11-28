using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.Description
{
    public class DescriptionProvider
    {
        private const string _sourceDateFormat = "yyyy-MM-dd";
        private static readonly Regex _pattern = new Regex(@"({[a-zA-Z0-9.-_]*})");
        private static readonly Regex _datePattern = new Regex(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$");

        public static string GetDescription(string format, JObject values, string dateFormat = null)
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
                        var value = variableValue.Value<string>();
                        if (!string.IsNullOrEmpty(dateFormat) &&
                            _datePattern.IsMatch(value))
                        {
                            var date = DateTime.ParseExact(value, _sourceDateFormat, CultureInfo.InvariantCulture);
                            value = date.ToString(dateFormat);
                        }

                        format = format.Replace(placeHolder, value);
                    }
                }
            }

            return format;
        }
    }
}
