using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Response.CompanyFiling;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseCompanyFilingHistoryClient
    {
        Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
    }
}