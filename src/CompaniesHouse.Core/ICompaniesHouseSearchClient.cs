using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchClient
    {
        Task<CompaniesHouseClientResponse<TSearch>> SearchAsync<TSearch>(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}