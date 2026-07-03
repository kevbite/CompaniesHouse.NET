using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;

namespace CompaniesHouse
{
    public interface ICompaniesHouseSearchOfficerClient
    {
        Task<CompaniesHouseResponse<OfficerSearch>> SearchOfficerAsync(SearchOfficerRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}