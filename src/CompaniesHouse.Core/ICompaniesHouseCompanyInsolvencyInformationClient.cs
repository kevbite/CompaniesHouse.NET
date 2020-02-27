using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Insolvency;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseCompanyInsolvencyInformationClient
    {
        Task<CompaniesHouseClientResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken));
    }
}