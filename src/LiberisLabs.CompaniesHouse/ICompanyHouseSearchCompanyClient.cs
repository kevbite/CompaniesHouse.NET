using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompanyHouseSearchCompanyClient
    {
        Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompany(CompanySearchRequest request);
    }
}