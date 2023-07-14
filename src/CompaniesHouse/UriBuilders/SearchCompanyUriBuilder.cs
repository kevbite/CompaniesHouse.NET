using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders;

public class SearchCompanyUriBuilder : SearchUriBuilder<SearchCompanyRequest>
{
    public SearchCompanyUriBuilder(string path) : base(path)
    {
    }

    protected override string BuildQuery(SearchCompanyRequest request)
    {
        var query = base.BuildQuery(request);

        if (string.IsNullOrWhiteSpace(request.Restrictions))
        {
            query += "&restrictions=" + request.Restrictions;
        }

        return query;
    }
}