using System;
using LiberisLabs.CompaniesHouse.Response.Search;
using LiberisLabs.CompaniesHouse.Response.Search.CompanySearch;
using LiberisLabs.CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using LiberisLabs.CompaniesHouse.Response.Search.OfficerSearch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LiberisLabs.CompaniesHouse.JsonConverters
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
