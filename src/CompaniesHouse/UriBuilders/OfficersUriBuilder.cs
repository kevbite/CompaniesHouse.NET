using System;
using System.Collections.Generic;
using System.Globalization;

namespace CompaniesHouse.UriBuilders
{
    public class OfficersUriBuilder : IOfficersUriBuilder
    {
        public Uri Build(string companyNumber, int startIndex, int pageSize, string? registerType, bool? registerView, string? orderBy)
        {
            var queryParts = new List<string>
            {
                "items_per_page=" + pageSize.ToString(CultureInfo.InvariantCulture),
                "start_index=" + startIndex.ToString(CultureInfo.InvariantCulture),
            };

            AddString("register_type", registerType);
            AddBool("register_view", registerView);
            AddString("order_by", orderBy);

            var query = "?" + string.Join("&", queryParts);
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/officers{query}";

            return new Uri(path, UriKind.Relative);

            void AddString(string key, string? value)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                queryParts.Add(key + "=" + Uri.EscapeDataString(value));
            }

            void AddBool(string key, bool? value)
            {
                if (!value.HasValue)
                {
                    return;
                }

                queryParts.Add(key + "=" + value.Value.ToString().ToLowerInvariant());
            }
        }
    }
}
