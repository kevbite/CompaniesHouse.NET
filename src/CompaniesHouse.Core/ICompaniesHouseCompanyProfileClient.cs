using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.CompanyProfile;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseCompanyProfileClient
    {
        Task<CompaniesHouseClientResponse<CompanyProfile>> GetCompanyProfileAsync(string companyNumber, CancellationToken cancellationToken = default(CancellationToken));
    }
}