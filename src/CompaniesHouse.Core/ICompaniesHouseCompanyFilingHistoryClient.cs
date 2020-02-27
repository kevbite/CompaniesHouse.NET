using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.CompanyFiling;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseCompanyFilingHistoryClient
    {
        Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
    }
}