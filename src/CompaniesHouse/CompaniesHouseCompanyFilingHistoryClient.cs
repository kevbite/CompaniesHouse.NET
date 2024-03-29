using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseCompanyFilingHistoryClient : ICompaniesHouseCompanyFilingHistoryClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICompanyFilingHistoryUriBuilder _companyFilingHistoryUriBuilder;

        public CompaniesHouseCompanyFilingHistoryClient(HttpClient httpClient, ICompanyFilingHistoryUriBuilder companyFilingHistoryUriBuilder)
        {
            _httpClient = httpClient;
            _companyFilingHistoryUriBuilder = companyFilingHistoryUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _companyFilingHistoryUriBuilder.Build(companyNumber, startIndex, pageSize);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            // Return a null profile on 404s, but raise exception for all other error codes
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode2();

            CompanyFilingHistory result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<CompanyFilingHistory>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<CompanyFilingHistory>(result);
        }

        public async Task<CompaniesHouseClientResponse<FilingHistoryItem>> GetFilingHistoryByTransactionAsync(string companyNumber, string transactionId, CancellationToken cancellationToken = default)
        {
            var requestUri = _companyFilingHistoryUriBuilder.Build(companyNumber, transactionId);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            // Return a null profile on 404s, but raise exception for all other error codes
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode2();

            var result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<FilingHistoryItem>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<FilingHistoryItem>(result);
        }
    }
}