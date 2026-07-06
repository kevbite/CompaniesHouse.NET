using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class ForeignCompanyAccounts
    {
        [JsonPropertyName("account_period_from")]
        public AccountingReferenceDate? AccountPeriodFrom { get; set; }

        [JsonPropertyName("account_period_to")]
        public AccountingReferenceDate? AccountPeriodTo { get; set; }

        [JsonPropertyName("must_file_within")]
        public MustFileWithin? MustFileWithin { get; set; }
    }
}
