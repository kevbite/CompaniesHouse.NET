using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;
using CompaniesHouse.Response.Search.CompanySearch;

namespace CompaniesHouse;

public interface ICompaniesHouseSearchCompanyAdvancedClient
{
    Task<CompaniesHouseClientResponse<AdvancedCompanySearch>> SearchCompanyAdvancedAsync(
        AdvancedSearchCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken));
}