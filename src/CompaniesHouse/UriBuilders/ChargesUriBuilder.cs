using System;

namespace CompaniesHouse.UriBuilders
{
    public class ChargesUriBuilder : IChargesUriBuilder
    {
        public Uri Build(string companyNumber) => 
            new Uri($"{CompaniesHouseUris.Default}company/{companyNumber}/charges");
    }
}