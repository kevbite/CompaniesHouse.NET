using System;
using CompaniesHouse.Core.Response.Search;
using CompaniesHouse.Core.Response.Search.CompanySearch;
using CompaniesHouse.Core.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Core.Response.Search.OfficerSearch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.Core.JsonConverters
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
