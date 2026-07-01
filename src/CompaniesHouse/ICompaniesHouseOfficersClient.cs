using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;

namespace CompaniesHouse
{
    public interface ICompaniesHouseOfficersClient
    {
        // Companies House defaults officer lists to 35 items, unlike several other paged endpoints.
        Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(
            string companyNumber,
            int startIndex = 0,
            int pageSize = 35,
            string? registerType = null,
            bool? registerView = null,
            string? orderBy = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}