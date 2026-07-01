using System;
using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class CompanyProfile
    {
        [JsonPropertyName("type")]
        public CompanyType Type { get; set; }

        [JsonPropertyName("etag")]
        public string ETag { get; set; }

        [JsonPropertyName("accounts")]
        public Accounts Accounts { get; set; }

        [JsonPropertyName("annual_return")]
        public AnnualReturn AnnualReturn { get; set; }

        [JsonPropertyName("confirmation_statement")]
        public ConfirmationStatement ConfirmationStatement { get; set; }

        [JsonPropertyName("can_file")]
        public bool? CanFile { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; }

        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("company_status_detail")]
        public CompanyStatusDetail CompanyStatusDetail { get; set; }

        [JsonPropertyName("subtype")]
        public CompanySubtype Subtype { get; set; }

        [JsonPropertyName("date_of_creation")]
        public DateTime? DateOfCreation { get; set; }

        [JsonPropertyName("date_of_cessation")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DateOfCessation { get; set; }

        [JsonPropertyName("has_been_liquidated")]
        public bool? HasBeenLiquidated { get; set; }

        [JsonPropertyName("has_charges")]
        public bool? HasCharges { get; set; }

        [JsonPropertyName("has_insolvency_history")]
        public bool? HasInsolvencyHistory { get; set; }

        [JsonPropertyName("has_super_secure_pscs")]
        public bool? HasSuperSecurePscs { get; set; }

        [JsonPropertyName("is_community_interest_company")]
        public bool? IsCommunityInterestCompany { get; set; }

        [JsonPropertyName("external_registration_number")]
        public string? ExternalRegistrationNumber { get; set; }

        [JsonPropertyName("foreign_company_details")]
        public ForeignCompanyDetails? ForeignCompanyDetails { get; set; }

        [JsonPropertyName("jurisdiction")]
        public Jurisdiction Jurisdiction { get; set; }

        [JsonPropertyName("last_full_members_list_date")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? LastFullMembersListDate { get; set; }

        [JsonPropertyName("links")]
        public CompanyProfileLinks Links { get; set; }

        [JsonPropertyName("previous_company_names")]
        public PreviousCompanyName[] PreviousCompanyNames { get; set; }

        [JsonPropertyName("registered_office_address")]
        public Address RegisteredOfficeAddress { get; set; }

        [JsonPropertyName("registered_office_is_in_dispute")]
        public bool? RegisteredOfficeIsInDispute { get; set; }

        [JsonPropertyName("sic_codes")]
        public string[] SicCodes { get; set; }

        [JsonPropertyName("undeliverable_registered_office_address")]
        public bool? UndeliverableRegisteredOfficeAddress { get; set; }

        [JsonPropertyName("branch_company_details")]
        public BranchCompanyDetails BranchCompanyDetails { get; set; }
    }
}
