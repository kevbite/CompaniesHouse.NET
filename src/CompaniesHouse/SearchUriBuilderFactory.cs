using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class SearchUriBuilderFactory : ISearchUriBuilderFactory
    {
        public ISearchUriBuilder<TSearch> Create<TSearch, TReturn>() where TSearch : SearchRequest<TReturn>
        {
            var type = typeof(TSearch);

            if (type == typeof(SearchCompanyRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchCompanyUriBuilder("search/companies");
            }
            else if (type == typeof(SearchOfficerRequest))
            {
                return new SearchUriBuilder<TSearch>("search/officers");
            }else if (type == typeof(SearchDisqualifiedOfficerRequest))
            {
                return new SearchUriBuilder<TSearch>("search/disqualified-officers");
            } else if (type == typeof(SearchAllRequest))
            {
                return new SearchUriBuilder<TSearch>("search");
            }

            throw new InvalidOperationException();
        }
    }
}