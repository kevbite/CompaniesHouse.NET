using System;

namespace CompaniesHouse.UriBuilders
{
    public interface ICompanyInsolvencyInformationUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
