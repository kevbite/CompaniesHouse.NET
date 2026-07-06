using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchClient
    {
        Task<CompaniesHouseResponse<TReturn>> SearchAsync<TSearchRequest, TReturn>(TSearchRequest request,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}