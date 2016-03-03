using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Response.CompanyFiling;
using LiberisLabs.CompaniesHouse.UriBuilders;

namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseCompanyFilingHistoryClient : ICompaniesHouseCompanyFilingHistoryClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICompanyFilingHistoryUriBuilder _companyFilingHistoryUriBuilder;

        public CompaniesHouseCompanyFilingHistoryClient(IHttpClientFactory httpClientFactory, ICompanyFilingHistoryUriBuilder companyFilingHistoryUriBuilder)
        {
            _httpClientFactory = httpClientFactory;
            _companyFilingHistoryUriBuilder = companyFilingHistoryUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var requestUri = _companyFilingHistoryUriBuilder.Build(companyNumber, startIndex, pageSize);

                var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

                // Return a null profile on 404s, but raise exception for all other error codes
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    response.EnsureSuccessStatusCode();

                CompanyFilingHistory result = response.IsSuccessStatusCode
                    ? await response.Content.ReadAsAsync<CompanyFilingHistory>(cancellationToken).ConfigureAwait(false)
                    : null;

                return new CompaniesHouseClientResponse<CompanyFilingHistory>(result);
            }
        }
    }
}