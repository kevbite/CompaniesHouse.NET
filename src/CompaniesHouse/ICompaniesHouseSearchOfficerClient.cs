using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchOfficerClient
    {
        Task<CompaniesHouseClientResponse<OfficerSearch>> SearchOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}