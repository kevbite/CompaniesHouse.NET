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

        public async Task<CompaniesHouseResponse<CompanyFilingHistory>> GetCompanyFilingHistoryAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _companyFilingHistoryUriBuilder.Build(companyNumber, startIndex, pageSize);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<CompanyFilingHistory>(cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<FilingHistoryItem>> GetFilingHistoryByTransactionAsync(string companyNumber, string transactionId, CancellationToken cancellationToken = default)
        {
            var requestUri = _companyFilingHistoryUriBuilder.Build(companyNumber, transactionId);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseResponseAsync<FilingHistoryItem>(cancellationToken).ConfigureAwait(false);
        }
    }
}