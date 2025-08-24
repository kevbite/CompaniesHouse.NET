using System;
using CompaniesHouse.Response.Search;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.JsonConverters
{
    public class SearchItemConverter : JsonCreationConverter<SearchItem>
    {
        protected override SearchItem Create(Type objectType, JObject jObject)
        {
            var kind = jObject.Value<string>("kind");
            if (kind is "searchresults#company")
            {
                return new Company();
            }
            if (kind is "search-results#company")
            {
                return new AdvancedSearchedCompany();
            }
            else if (kind is "searchresults#officer")
            {
                return new Officer();
            }
            else if (kind is "searchresults#disqualified-officer")
            {
                return new DisqualifiedOfficer();
            }

            throw new NotImplementedException();
        }
    }
}
