using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Response.CompanyFiling;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseCompanyFilingHistoryClient
    {
        Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyProfileAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken));
    }
}