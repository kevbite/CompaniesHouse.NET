using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Officers;
using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
{
    public class CompaniesHouseOfficersClient : ICompaniesHouseOfficersClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOfficersUriBuilder _officersUriBuilder;

        public CompaniesHouseOfficersClient(HttpClient httpClient, IOfficersUriBuilder officersUriBuilder)
        {
            _httpClient = httpClient;
            _officersUriBuilder = officersUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _officersUriBuilder.Build(companyNumber, startIndex, pageSize);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            // Return a null profile on 404s, but raise exception for all other error codes
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                response.EnsureSuccessStatusCode();

            var result = response.IsSuccessStatusCode
                ? await response.Content.ReadAsJsonAsync<Officers>().ConfigureAwait(false)
                : null;

            return new CompaniesHouseClientResponse<Officers>(result);
        }
    }
}