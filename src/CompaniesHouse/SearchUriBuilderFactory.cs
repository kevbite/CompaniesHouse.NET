using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class SearchUriBuilderFactory : ISearchUriBuilderFactory
    {
        public ISearchUriBuilder<TSearch> Create<TSearch, TReturn>()
        {
            var type = typeof(TSearch);

            if (type == typeof(SearchCompanyRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchCompanyUriBuilder("search/companies");
            }
            else if (type == typeof(SearchOfficerRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchUriBuilder<SearchOfficerRequest>("search/officers");
            }
            else if (type == typeof(SearchDisqualifiedOfficerRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchUriBuilder<SearchDisqualifiedOfficerRequest>("search/disqualified-officers");
            }
            else if (type == typeof(SearchAllRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchUriBuilder<SearchAllRequest>("search");
            }
            else if (type == typeof(SearchCompaniesAlphabeticallyRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchCompaniesAlphabeticallyUriBuilder("alphabetical-search/companies");
            }
            else if (type == typeof(SearchDissolvedCompaniesRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchDissolvedCompaniesUriBuilder("dissolved-search/companies");
            }
            else if (type == typeof(AdvancedCompanySearchRequest))
            {
                return (ISearchUriBuilder<TSearch>)new AdvancedCompanySearchUriBuilder("advanced-search/companies");
            }

            throw new InvalidOperationException();
        }
    }
}