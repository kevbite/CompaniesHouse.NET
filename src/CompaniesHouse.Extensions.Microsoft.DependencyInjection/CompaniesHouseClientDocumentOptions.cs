using System;

namespace CompaniesHouse.Extensions.Microsoft.DependencyInjection
{
    public class CompaniesHouseClientDocumentOptions
    {
        public Uri BaseUri { get; set; } = CompaniesHouseUris.DocumentApi;
        public string ApiKey { get; set; }
    }
}