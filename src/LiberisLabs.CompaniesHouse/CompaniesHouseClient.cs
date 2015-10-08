using System;
using System.Net;
using System.Net.Http;
using LiberisLabs.CompaniesHouse.DelegatingHandlers;

namespace LiberisLabs.CompaniesHouse
{
    public interface ICompaniesHouseSettings
    {
        Uri BaseUri { get; }

        string ApiKey { get; }
    }

    public class CompaniesHouseSettings : ICompaniesHouseSettings
    {
        public CompaniesHouseSettings(Uri baseUri, string apiKey)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
        }   

        public Uri BaseUri { get; }

        public string ApiKey { get; }
    }

    public class CompaniesHouseClient
    {
        private readonly ICompaniesHouseSettings _settings;
        
        public CompaniesHouseClient(ICompaniesHouseSettings settings)
        {
            _settings = settings;
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
