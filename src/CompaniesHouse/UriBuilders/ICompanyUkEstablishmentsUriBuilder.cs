using System;

namespace CompaniesHouse.UriBuilders
{
    public interface ICompanyUkEstablishmentsUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
