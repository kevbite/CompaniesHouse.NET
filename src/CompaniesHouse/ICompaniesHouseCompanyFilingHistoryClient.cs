using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;

namespace CompaniesHouse
{
    public interface ICompaniesHouseCompanyFilingHistoryClient
    {
        Task<CompaniesHouseResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
        Task<CompaniesHouseResponse<FilingHistoryItem>> GetFilingHistoryByTransactionAsync(string companyNumber, string transactionId, CancellationToken cancellationToken = default);
    }
}