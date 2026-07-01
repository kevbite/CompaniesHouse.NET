using System;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders
{
    public interface ISearchUriBuilder<in TSearch>
    {
        Uri Build(TSearch request);
    }
}