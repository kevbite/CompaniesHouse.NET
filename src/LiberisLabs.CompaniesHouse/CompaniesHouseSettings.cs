using System;

namespace LiberisLabs.CompaniesHouse
{
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
}