using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class BranchCompanyDetails
    {
        [JsonPropertyName("business_activity")]
        public string BusinessActivity { get; set; }
        [JsonPropertyName("parent_company_name")]
        public string ParentCompanyName { get; set; }
        [JsonPropertyName("parent_company_number")]
        public string ParentCompanyNumber { get; set; }
    }
}
