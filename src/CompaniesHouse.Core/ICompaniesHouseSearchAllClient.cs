using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.AllSearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchAllClient
    {
        Task<CompaniesHouseClientResponse<AllSearch>> SearchAllAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}