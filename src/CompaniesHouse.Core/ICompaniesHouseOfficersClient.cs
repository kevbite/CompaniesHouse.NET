using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Officers;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseOfficersClient
    {
        Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken));
    }
}