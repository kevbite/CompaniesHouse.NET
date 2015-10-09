using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.UriBuilders;

namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseClient : ICompaniesHouseClient
    {
        private readonly ICompanyHouseSearchCompanyClient _companyHouseSearchCompanyClient;

        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            var httpClientFactory = new HttpClientFactory(settings);

            _companyHouseSearchCompanyClient = new CompanyHouseSearchCompanyClient(httpClientFactory, new CompanySearchUriBuilder());
        }

        public Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompany(CompanySearchRequest request)
        {
            return _companyHouseSearchCompanyClient.SearchCompany(request);
        }
    }
}
