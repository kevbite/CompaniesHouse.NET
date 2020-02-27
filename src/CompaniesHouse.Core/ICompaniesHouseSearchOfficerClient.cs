using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Request;
using CompaniesHouse.Core.Response.Search.OfficerSearch;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseSearchOfficerClient
    {
        Task<CompaniesHouseClientResponse<OfficerSearch>> SearchOfficerAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}