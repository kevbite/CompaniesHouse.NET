using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseSearchClient
    {
        Task<CompaniesHouseClientResponse<TSearch>> SearchAsync<TSearch>(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}