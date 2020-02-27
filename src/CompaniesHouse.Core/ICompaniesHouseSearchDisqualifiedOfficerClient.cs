using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Request;
using CompaniesHouse.Core.Response.Search.DisqualifiedOfficersSearch;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseSearchDisqualifiedOfficerClient
    {
        Task<CompaniesHouseClientResponse<DisqualifiedOfficerSearch>> SearchDisqualifiedOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}