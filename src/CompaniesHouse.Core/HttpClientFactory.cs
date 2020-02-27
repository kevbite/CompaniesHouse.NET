using System.Net;
using System.Net.Http;
using CompaniesHouse.Core.DelegatingHandlers;

namespace CompaniesHouse.Core
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

            var companiesHouseAuthorizationHandler = new CompaniesHouseAuthorizationHandler(_settings.ApiKey)
            {
                InnerHandler = httpClientHandler
            };

            var httpClient = new HttpClient(companiesHouseAuthorizationHandler)
            {
                BaseAddress = _settings.BaseUri
            };


            return httpClient;
        }
    }
}