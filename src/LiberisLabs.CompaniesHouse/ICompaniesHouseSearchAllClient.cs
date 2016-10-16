using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.Search.AllSearch;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseSearchAllClient
    {
        Task<CompaniesHouseClientResponse<AllSearch>> SearchAllAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}