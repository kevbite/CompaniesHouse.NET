﻿using System.Net;
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
            var staticApiKeyProvider = new StaticApiKeyProvider(_settings.ApiKey);
            var companiesHouseAuthorizationHandler = new CompaniesHouseAuthorizationHandler(staticApiKeyProvider)
            {
                InnerHandler = _settings.HttpMessageHandlerCreator()
            };

            var httpClient = new HttpClient(companiesHouseAuthorizationHandler)
            {
                BaseAddress = _settings.BaseUri
            };


            return httpClient;
        }
    }
}