using System;
using System.Collections.Generic;
using CompaniesHouse.Core.Response.Search.AllSearch;
using CompaniesHouse.Core.Response.Search.CompanySearch;
using CompaniesHouse.Core.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Core.Response.Search.OfficerSearch;
using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
{
    public class SearchUriBuilderFactory : ISearchUriBuilderFactory
    {
        public ISearchUriBuilder Create<TSearch>()
        {
            var type = typeof(TSearch);

            return _map[type]();
        }

        private readonly IDictionary<Type, Func<ISearchUriBuilder>> _map = new Dictionary
            <Type, Func<ISearchUriBuilder>>()
            {
                {typeof(CompanySearch), () => new SearchUriBuilder("search/companies")},
                {typeof(OfficerSearch), () => new SearchUriBuilder("search/officers")},
                {typeof(DisqualifiedOfficerSearch), () => new SearchUriBuilder("search/disqualified-officers")},
                {typeof(AllSearch), () => new SearchUriBuilder("search")}
            };
    }
}