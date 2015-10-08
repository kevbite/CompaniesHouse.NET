using System.Net;
using System.Net.Http;
using LiberisLabs.CompaniesHouse.DelegatingHandlers;
using LiberisLabs.CompaniesHouse.Request;

namespace LiberisLabs.CompaniesHouse
{


    public class CompaniesHouseClient
    {
        private readonly ICompaniesHouseSettings _settings;
        
        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            _settings = settings;
        }

        public void SearchCompany(CompanySearchRequest request)
        {
            using (var httpClient = CreateHttpClient())
            {
 
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };


            var httpClient = HttpClientFactory.Create(httpClientHandler, new CompaniesHouseAuthorizationHandler(_settings.ApiKey));
            
            httpClient.BaseAddress = _settings.BaseUri;

            return httpClient;
        }
    }
}
