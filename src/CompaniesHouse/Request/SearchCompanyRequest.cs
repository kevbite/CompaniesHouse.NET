#nullable enable
using CompaniesHouse.Response.Search.CompanySearch;

namespace CompaniesHouse.Request;

public class SearchCompanyRequest : QuerySearchRequest<CompanySearch>
{
    public string? Restrictions { get; set; }
}