using System.Text;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders;

public class SearchCompanyUriBuilder : SearchUriBuilder<SearchCompanyRequest>
{
    public SearchCompanyUriBuilder(string path) : base(path)
    {
    }

    protected override string BuildQuery(SearchCompanyRequest request)
    {
        var queryBuilder = new StringBuilder(base.BuildQuery(request));

        AppendParameterIfValid(queryBuilder, "restrictions", request.Restrictions, value => !string.IsNullOrWhiteSpace(value));

        return queryBuilder.ToString();
    }
}