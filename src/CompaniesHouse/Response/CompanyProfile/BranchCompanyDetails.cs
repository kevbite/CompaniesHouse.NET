using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class BranchCompanyDetails
    {
        [JsonProperty(PropertyName = "business_activity")]
        public string BusinessActivity { get; set; }
        [JsonProperty(PropertyName = "parent_company_name")]
        public string ParentCompanyName { get; set; }
        [JsonProperty(PropertyName = "parent_company_number")]
        public string ParentCompanyNumber { get; set; }
    }
}