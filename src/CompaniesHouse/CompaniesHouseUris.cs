using System;

namespace CompaniesHouse
{
    public static class CompaniesHouseUris
    {
        // Breaking change: the old default host (api.companieshouse.gov.uk) is superseded by
        // the current Companies House Public Data API host.
        public static readonly Uri Default = new Uri("https://api.company-information.service.gov.uk/");
        public static readonly Uri DocumentApi = new Uri("https://document-api.companieshouse.gov.uk/");
    }
}