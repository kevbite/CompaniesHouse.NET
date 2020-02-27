using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Request;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseSearchClient
    {
        Task<CompaniesHouseClientResponse<TSearch>> SearchAsync<TSearch>(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}