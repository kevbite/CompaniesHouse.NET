using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LiberisLabs.CompaniesHouse.DelegatingHandlers;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.UriBuilders;

namespace LiberisLabs.CompaniesHouse
{
    public class CompaniesHouseClientResponse<T>
    {
        public CompaniesHouseClientResponse(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }

    public class CompanyHouseSearchCompanyClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICompanySearchUriBuilder _companySearchUriBuilder;

        public CompanyHouseSearchCompanyClient(IHttpClientFactory httpClientFactory, ICompanySearchUriBuilder companySearchUriBuilder)
        {
            _httpClientFactory = httpClientFactory;
            _companySearchUriBuilder = companySearchUriBuilder;
        }

        public async Task<CompaniesHouseClientResponse<CompanySearch>> SearchCompany(CompanySearchRequest request)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var requestUri = _companySearchUriBuilder.Build(request);

                var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsAsync<CompanySearch>().ConfigureAwait(false);

                return new CompaniesHouseClientResponse<CompanySearch>(result);
            }

        }
    }

    public class CompaniesHouseClient
    {
        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            
        }

    }

    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly ICompaniesHouseSettings _settings;

        public HttpClientFactory(ICompaniesHouseSettings settings)
        {
            _settings = settings;
        }

        public HttpClient CreateHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };


            var httpClient = System.Net.Http.HttpClientFactory.Create(httpClientHandler, new CompaniesHouseAuthorizationHandler(_settings.ApiKey));

            httpClient.BaseAddress = _settings.BaseUri;

            return httpClient;
        }
    }

    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}
