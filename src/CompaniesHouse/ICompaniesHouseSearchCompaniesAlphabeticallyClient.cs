using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchCompaniesAlphabeticallyClient
    {
        Task<CompaniesHouseResponse<CompaniesAlphabeticallySearch>> SearchCompaniesAlphabeticallyAsync(SearchCompaniesAlphabeticallyRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
