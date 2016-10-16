using System.Net;
using System.Net.Http;
using CompaniesHouse.DelegatingHandlers;

namespace CompaniesHouse
{
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
}