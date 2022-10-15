using System;

namespace CompaniesHouse.Extensions.Microsoft.DependencyInjection
{
    public class CompaniesHouseClientOptions
    {
        public Uri BaseUri { get; set; } = CompaniesHouseUris.Default;
        public string ApiKey { get; set; }
    }
}