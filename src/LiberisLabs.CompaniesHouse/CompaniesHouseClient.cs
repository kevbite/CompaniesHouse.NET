using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.UriBuilders;

namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseClient : ICompaniesHouseClient
    {
        private readonly ICompaniesHouseSearchCompanyClient _companiesHouseSearchCompanyClient;

        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            var httpClientFactory = new HttpClientFactory(settings);

            _companiesHouseSearchCompanyClient = new CompaniesHouseSearchCompanyClient(httpClientFactory, new CompanySearchUriBuilder());
        }

        public Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompanyAsync(CompanySearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _companiesHouseSearchCompanyClient.SearchCompanyAsync(request, cancellationToken);
        }
    }
}
