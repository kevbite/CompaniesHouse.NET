using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchClient
    {
        Task<CompaniesHouseClientResponse<TReturn>> SearchAsync<TSearchRequest, TReturn>(TSearchRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
            where TSearchRequest : SearchRequest<TReturn>;
    }
}