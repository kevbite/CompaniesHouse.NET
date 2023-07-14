using CompaniesHouse.Response.Search.CompanySearch;

namespace CompaniesHouse.Request;

public class SearchCompanyRequest : SearchRequest<CompanySearch>
{
    public string Restrictions { get; set; }
}