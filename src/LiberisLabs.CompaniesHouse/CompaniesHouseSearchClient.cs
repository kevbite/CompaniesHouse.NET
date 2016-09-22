using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.Request;

namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseSearchClient : ICompaniesHouseSearchClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISearchUriBuilderFactory _searchUriBuilderFactory;

        public CompaniesHouseSearchClient(IHttpClientFactory httpClientFactory, ISearchUriBuilderFactory searchUriBuilderFactory)
        {
            _httpClientFactory = httpClientFactory;
            _searchUriBuilderFactory = searchUriBuilderFactory;
        }

        public async Task<CompaniesHouseClientResponse<TSearch>> SearchAsync<TSearch>(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var searchUriBuilder = _searchUriBuilderFactory.Create<TSearch>();
                var requestUri = searchUriBuilder.Build(request);

                var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsAsync<TSearch>(cancellationToken).ConfigureAwait(false);

                return new CompaniesHouseClientResponse<TSearch>(result);
            }

        }
    }
}