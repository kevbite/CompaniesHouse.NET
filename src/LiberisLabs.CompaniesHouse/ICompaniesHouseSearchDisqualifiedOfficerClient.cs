using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.DisqualifiedOfficersSearch;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseSearchDisqualifiedOfficerClient
    {
        Task<CompaniesHouseClientResponse<DisqualifiedOfficerSearch>> SearchDisqualifiedOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));

    }
}