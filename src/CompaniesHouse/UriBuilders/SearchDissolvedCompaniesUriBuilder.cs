using System;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders;

public class SearchDissolvedCompaniesUriBuilder : ISearchUriBuilder<SearchDissolvedCompaniesRequest>
{
    private readonly string _path;

    public SearchDissolvedCompaniesUriBuilder(string path)
    {
        _path = path;
    }

    public Uri Build(SearchDissolvedCompaniesRequest request)
    {
        var query = $"?q={Uri.EscapeDataString(request.Query)}&search_type={Uri.EscapeDataString(request.SearchType)}";

        if (!string.IsNullOrWhiteSpace(request.SearchAbove))
        {
            query += "&search_above=" + Uri.EscapeDataString(request.SearchAbove);
        }

        if (!string.IsNullOrWhiteSpace(request.SearchBelow))
        {
            query += "&search_below=" + Uri.EscapeDataString(request.SearchBelow);
        }

        if (request.Size.HasValue)
        {
            query += "&size=" + request.Size.Value;
        }

        if (request.StartIndex.HasValue)
        {
            query += "&start_index=" + request.StartIndex.Value;
        }

        return new Uri(_path + query, UriKind.Relative);
    }
}
