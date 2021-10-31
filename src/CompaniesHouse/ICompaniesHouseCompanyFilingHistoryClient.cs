using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;

namespace CompaniesHouse
{
    public interface ICompaniesHouseCompanyFilingHistoryClient
    {
        Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
        Task<CompaniesHouseClientResponse<FilingHistoryItem>> GetFilingHistoryByTransactionAsync(string companyNumber, string transactionId, CancellationToken cancellationToken = default);
    }
}