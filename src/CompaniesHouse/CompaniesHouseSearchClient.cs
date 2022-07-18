using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Request;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHouseSearchClient : ICompaniesHouseSearchClient
    {
        private readonly HttpClient _httpClient;
        private readonly ISearchUriBuilderFactory _searchUriBuilderFactory;

        public CompaniesHouseSearchClient(HttpClient httpClient, ISearchUriBuilderFactory searchUriBuilderFactory)
        {
            _httpClient = httpClient;
            _searchUriBuilderFactory = searchUriBuilderFactory;
        }

        public async Task<CompaniesHouseClientResponse<TSearch>> SearchAsync<TSearch>(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var searchUriBuilder = _searchUriBuilderFactory.Create<TSearch>();
            var requestUri = searchUriBuilder.Build(request);

            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            response.EnsureSuccessStatusCode2();

            var result = await response.Content.ReadAsJsonAsync<TSearch>().ConfigureAwait(false);

            return new CompaniesHouseClientResponse<TSearch>(result);
        }
    }
}