#nullable enable
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;
using CompaniesHouse.Response.Search.CompanySearch;

namespace CompaniesHouse.Request;

public class AdvancedSearchCompanyRequest : SearchRequest<AdvancedCompanySearch>
{
    public string? CompanyNameIncludes { get; set; }
    public string? CompanyNameExcludes { get; set; }
    public IReadOnlyCollection<CompanyStatus> CompanyStatus { get; set; } = [];
    public IReadOnlyCollection<CompanySubType> CompanySubtype { get; set; } = [];
    public IReadOnlyCollection<CompanyType> CompanyType { get; set; } = [];
    public DateTime? DissolvedFrom { get; set; }
    public DateTime? DissolvedTo { get; set; }
    public DateTime? IncorporatedFrom { get; set; }
    public DateTime? IncorporatedTo { get; set; }
    public string? Location { get; set; }
    public IReadOnlyCollection<string> SicCodes { get; set; } = [];
}