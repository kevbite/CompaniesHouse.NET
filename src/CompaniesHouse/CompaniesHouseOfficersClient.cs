using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class CompaniesHouseOfficersClient : ICompaniesHouseOfficersClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOfficersUriBuilder _officersUriBuilder;

        public CompaniesHouseOfficersClient(IHttpClientFactory httpClientFactory, IOfficersUriBuilder officersUriBuilder)
        {
            _httpClientFactory = httpClientFactory;
            _officersUriBuilder = officersUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var requestUri = _officersUriBuilder.Build(companyNumber, startIndex, pageSize);

                var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

                // Return a null profile on 404s, but raise exception for all other error codes
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    response.EnsureSuccessStatusCode();

                Officers result = response.IsSuccessStatusCode
                    ? await response.Content.ReadAsAsync<Officers>(cancellationToken).ConfigureAwait(false)
                    : null;

                return new CompaniesHouseClientResponse<Officers>(result);
            }
        }
    }
}