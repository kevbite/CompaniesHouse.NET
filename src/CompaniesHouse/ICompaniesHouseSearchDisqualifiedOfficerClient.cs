using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchDisqualifiedOfficerClient
    {
        Task<CompaniesHouseClientResponse<DisqualifiedOfficerSearch>> SearchDisqualifiedOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}