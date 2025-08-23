using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;

namespace CompaniesHouse;

public interface ICompaniesHouseSearchCompanyAdvancedClient
{
    Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAdvancedAsync(
        AdvancedSearchCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken));
}