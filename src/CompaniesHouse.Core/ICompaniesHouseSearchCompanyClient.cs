using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Request;
using CompaniesHouse.Core.Response.Search.CompanySearch;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseSearchCompanyClient
    {
        Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}