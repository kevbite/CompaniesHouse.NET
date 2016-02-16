using LiberisLabs.CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LiberisLabs.CompaniesHouse.Response.CompanyProfile
{
    public class CompanyProfile
    {
        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        [JsonProperty(PropertyName = "accounts")]
        public Accounts Accounts { get; set; }

        [JsonProperty(PropertyName = "annual_return")]
        public AnnualReturn AnnualReturn { get; set; }

        [JsonProperty(PropertyName = "can_file")]
        public bool? CanFile { get; set; }

        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "company_number")]
        public string CompanyNumber { get; set; }

        [JsonProperty(PropertyName = "company_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonProperty(PropertyName = "company_status_detail")]
        public string CompanyStatusDetail { get; set; }

        [JsonProperty(PropertyName = "date_of_creation")]
        public DateTime? DateOfCreation { get; set; }

        [JsonProperty(PropertyName = "date_of_dissolution")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DateOfDissolution { get; set; }

        [JsonProperty(PropertyName = "has_been_liquidated")]
        public bool? HasBeenLiquidated { get; set; }

        [JsonProperty(PropertyName = "has_charges")]
        public bool? HasCharges { get; set; }

        [JsonProperty(PropertyName = "has_insolvency_history")]
        public bool? HasInsolvencyHistory { get; set; }

        [JsonProperty(PropertyName = "is_community_interest_company")]
        public bool? IsCommunityInterestCompany { get; set; }

        [JsonProperty(PropertyName = "jurisdiction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Jurisdiction Jurisdiction { get; set; }

        [JsonProperty(PropertyName = "last_full_members_list_date")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? LastFullMembersListDate { get; set; }

        [JsonProperty(PropertyName = "officer_summary")]
        public OfficerSummary OfficerSummary { get; set; }

        [JsonProperty(PropertyName = "registered_office_address")]
        public Address RegisteredOfficeAddress { get; set; }

        [JsonProperty(PropertyName = "registered_office_is_in_dispute")]
        public bool? RegisteredOfficeIsInDispute { get; set; }

        [JsonProperty(PropertyName = "sic_codes")]
        public string[] SicCodes { get; set; }

        [JsonProperty(PropertyName = "type")]
        public CompanyType Type { get; set; }

        [JsonProperty(PropertyName = "undeliverable_registered_office_address")]
        public bool? UndeliverableRegisteredOfficeAddress { get; set; }
    }
}