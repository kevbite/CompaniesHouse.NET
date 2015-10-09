using System;
using LiberisLabs.CompaniesHouse.Request;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public interface ICompanySearchUriBuilder
    {
        Uri Build(CompanySearchRequest request);
    }
}