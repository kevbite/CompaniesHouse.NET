using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Exemptions;

namespace CompaniesHouse
{
    public interface ICompaniesHouseExemptionsClient
    {
        Task<CompaniesHouseResponse<CompanyExemptions>> GetCompanyExemptionsAsync(string companyNumber, CancellationToken cancellationToken = default);
    }
}
