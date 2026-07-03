using System;

namespace CompaniesHouse.UriBuilders
{
    public interface ICompanyRegistersUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
