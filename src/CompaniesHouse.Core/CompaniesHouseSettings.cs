using System;

namespace CompaniesHouse
{
    public class CompaniesHouseSettings : ICompaniesHouseSettings
    {

        public CompaniesHouseSettings(Uri baseUri, string apiKey)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
        }

        public CompaniesHouseSettings(string apiKey)
            :this(CompaniesHouseUris.Default, apiKey)
        {
        }

        public Uri BaseUri { get; }

        public string ApiKey { get; }
    }
}