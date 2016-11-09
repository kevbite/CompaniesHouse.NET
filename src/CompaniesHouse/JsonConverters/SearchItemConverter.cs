using System;
using CompaniesHouse.Response.Search;
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
            if (kind == "searchresults#company")
            {
                return new Company();
            }
            else if (kind == "searchresults#officer")
            {
                return new Officer();
            }
            else if (kind == "searchresults#disqualified-officer")
            {
                return new DisqualifiedOfficer();
            }

            throw new NotImplementedException();
        }
    }
}
