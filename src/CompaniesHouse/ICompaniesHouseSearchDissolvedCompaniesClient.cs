using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.DissolvedCompaniesSearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchDissolvedCompaniesClient
    {
        Task<CompaniesHouseResponse<DissolvedCompaniesSearch>> SearchDissolvedCompaniesAsync(SearchDissolvedCompaniesRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
