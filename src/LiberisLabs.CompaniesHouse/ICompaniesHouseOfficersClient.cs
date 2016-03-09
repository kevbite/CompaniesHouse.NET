using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Response.Officers;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseOfficersClient
    {
        Task<CompaniesHouseClientResponse<Officers>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
    }
}