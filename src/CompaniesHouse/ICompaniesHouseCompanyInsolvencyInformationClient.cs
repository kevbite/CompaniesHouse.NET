using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;

namespace CompaniesHouse
{
    public interface ICompaniesHouseCompanyInsolvencyInformationClient
    {
        Task<CompaniesHouseResponse<CompanyInsolvencyInformation>> GetCompanyInsolvencyInformationAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken));
    }
}