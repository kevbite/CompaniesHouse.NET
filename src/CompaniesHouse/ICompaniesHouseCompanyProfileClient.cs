using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyProfile;

namespace CompaniesHouse
{
    public interface ICompaniesHouseCompanyProfileClient
    {
        Task<CompaniesHouseClientResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken));
    }
}