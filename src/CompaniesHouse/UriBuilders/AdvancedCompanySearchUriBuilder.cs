using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders;

public class AdvancedCompanySearchUriBuilder : ISearchUriBuilder<AdvancedCompanySearchRequest>
{
    private readonly string _path;

    public AdvancedCompanySearchUriBuilder(string path)
    {
        _path = path;
    }

    public Uri Build(AdvancedCompanySearchRequest request)
    {
        var queryParts = new List<string>();

        AddString("company_name_includes", request.CompanyNameIncludes);
        AddString("company_name_excludes", request.CompanyNameExcludes);
        AddDelimited("company_status", request.CompanyStatuses?.Select(x => x.Value));
        AddDelimited("company_subtype", request.CompanySubtypes?.Select(x => x.Value));
        AddDelimited("company_type", request.CompanyTypes?.Select(x => x.Value));
        AddDate("dissolved_from", request.DissolvedFrom);
        AddDate("dissolved_to", request.DissolvedTo);
        AddDate("incorporated_from", request.IncorporatedFrom);
        AddDate("incorporated_to", request.IncorporatedTo);
        AddString("location", request.Location);
        AddDelimited("sic_codes", request.SicCodes);

        if (request.Size.HasValue)
        {
            queryParts.Add("size=" + request.Size.Value);
        }

        if (request.StartIndex.HasValue)
        {
            queryParts.Add("start_index=" + request.StartIndex.Value);
        }

        var query = queryParts.Count == 0 ? string.Empty : "?" + string.Join("&", queryParts);

        return new Uri(_path + query, UriKind.Relative);

        void AddString(string key, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            queryParts.Add(key + "=" + Uri.EscapeDataString(value));
        }

        void AddDelimited(string key, IEnumerable<string>? values)
        {
            if (values is null)
            {
                return;
            }

            var nonEmptyValues = values.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            if (nonEmptyValues.Length == 0)
            {
                return;
            }

            queryParts.Add(key + "=" + Uri.EscapeDataString(string.Join(",", nonEmptyValues)));
        }

        void AddDate(string key, DateTime? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            queryParts.Add(key + "=" + value.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
