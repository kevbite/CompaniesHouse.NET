using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class ForeignCompanyAccountingRequirement
    {
        [JsonPropertyName("foreign_account_type")]
        public ForeignAccountType ForeignAccountType { get; set; }

        [JsonPropertyName("terms_of_account_publication")]
        public TermsOfAccountPublication TermsOfAccountPublication { get; set; }
    }
}
