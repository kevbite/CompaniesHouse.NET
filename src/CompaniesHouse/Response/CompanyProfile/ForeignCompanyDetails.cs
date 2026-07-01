using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class ForeignCompanyDetails
    {
        [JsonPropertyName("accounting_requirement")]
        public ForeignCompanyAccountingRequirement? AccountingRequirement { get; set; }

        [JsonPropertyName("accounts")]
        public ForeignCompanyAccounts? Accounts { get; set; }

        [JsonPropertyName("business_activity")]
        public string? BusinessActivity { get; set; }

        [JsonPropertyName("governed_by")]
        public string? GovernedBy { get; set; }

        [JsonPropertyName("is_a_credit_financial_institution")]
        public bool? IsACreditFinancialInstitution { get; set; }

        [JsonPropertyName("originating_registry")]
        public ForeignCompanyOriginatingRegistry? OriginatingRegistry { get; set; }

        [JsonPropertyName("registration_number")]
        public string? RegistrationNumber { get; set; }

        [JsonPropertyName("legal_form")]
        public string? LegalForm { get; set; }
    }
}
