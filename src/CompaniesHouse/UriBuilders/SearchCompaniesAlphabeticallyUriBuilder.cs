using System;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders;

public class SearchCompaniesAlphabeticallyUriBuilder : ISearchUriBuilder<SearchCompaniesAlphabeticallyRequest>
{
    private readonly string _path;

    public SearchCompaniesAlphabeticallyUriBuilder(string path)
    {
        _path = path;
    }

    public Uri Build(SearchCompaniesAlphabeticallyRequest request)
    {
        var query = $"?q={Uri.EscapeDataString(request.Query)}";

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

        return new Uri(_path + query, UriKind.Relative);
    }
}
