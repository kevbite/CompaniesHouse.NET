using System;
using System.Collections.Generic;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.AllSearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class SearchUriBuilderFactory : ISearchUriBuilderFactory
    {
        public ISearchUriBuilder<TSearch> Create<TSearch, TReturn>() where TSearch : SearchRequest<TReturn>
        {
            var type = typeof(TSearch);

            if (type == typeof(CompanySearch))
            {
                return (ISearchUriBuilder<TSearch>)new SearchCompanyUriBuilder("search/companies");
            }else if (type == typeof(OfficerSearch))
            {
                return new SearchUriBuilder<TSearch>("search/officers");
            }else if (type == typeof(DisqualifiedOfficerSearch))
            {
                return new SearchUriBuilder<TSearch>("search/disqualified-officers");
            } else if (type == typeof(AllSearch))
            {
                return new SearchUriBuilder<TSearch>("search");
            }

            throw new InvalidOperationException();
        }
    }
}