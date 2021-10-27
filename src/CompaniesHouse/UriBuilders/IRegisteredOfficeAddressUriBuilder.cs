using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IRegisteredOfficeAddressUriBuilder
    {
        
        Uri Build(string companyNumber);
    }
}