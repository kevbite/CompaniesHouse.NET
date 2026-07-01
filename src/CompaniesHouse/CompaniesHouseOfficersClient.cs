using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseOfficersClient : ICompaniesHouseOfficersClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOfficersUriBuilder _officersUriBuilder;

        public CompaniesHouseOfficersClient(HttpClient httpClient, IOfficersUriBuilder officersUriBuilder)
        {
            _httpClient = httpClient;
            _officersUriBuilder = officersUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<Officers>> GetOfficersAsync(
            string companyNumber,
            int startIndex,
            int pageSize,
            string? registerType = null,
            bool? registerView = null,
            string? orderBy = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUri = _officersUriBuilder.Build(companyNumber, startIndex, pageSize, registerType, registerView, orderBy);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            return await response.ToCompaniesHouseClientResponseAsync<Officers>(cancellationToken).ConfigureAwait(false);
        }
    }
}