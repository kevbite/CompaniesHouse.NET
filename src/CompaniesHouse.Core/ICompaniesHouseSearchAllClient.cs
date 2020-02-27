using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Request;
using CompaniesHouse.Core.Response.Search.AllSearch;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseSearchAllClient
    {
        Task<CompaniesHouseClientResponse<AllSearch>> SearchAllAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}