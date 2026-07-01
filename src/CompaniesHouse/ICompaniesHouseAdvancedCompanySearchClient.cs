using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseAdvancedCompanySearchClient
    {
        Task<CompaniesHouseClientResponse<AdvancedCompanySearch>> AdvancedCompanySearchAsync(AdvancedCompanySearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
