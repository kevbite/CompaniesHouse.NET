using System.Text.Json;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class CompanyProfileDeserializationScenarioTests
    {
        [Fact]
        public void PlainCompanyProfile_DeserializesKnownFields()
        {
            var profile = JsonSerializer.Deserialize<CompanyProfile>(PlainCompanyJson, CompaniesHouseJsonSerializerOptions.Default);

            profile.ShouldNotBeNull();
            profile.CompanyNumber.ShouldBe("00445790");
            profile.CompanyStatus.ShouldBe(CompanyStatus.Active);
            profile.Type.ShouldBe(CompanyType.Plc);
            profile.Jurisdiction.ShouldBe(Jurisdiction.EnglandWales);
            profile.HasSuperSecurePscs.ShouldBe(false);
            profile.Links.Exemptions.ShouldBe("/company/00445790/exemptions");
            profile.PreviousCompanyNames.Length.ShouldBe(2);
            profile.SicCodes.ShouldBe(["47110"]);
        }

        [Fact]
        public void ForeignCompanyProfile_DeserializesForeignCompanyDetails()
        {
            var profile = JsonSerializer.Deserialize<CompanyProfile>(ForeignCompanyJson, CompaniesHouseJsonSerializerOptions.Default);

            profile.ShouldNotBeNull();
            profile.CompanyNumber.ShouldBe("FC040879");
            profile.Type.ShouldBe(CompanyType.OverseaCompany);
            profile.ExternalRegistrationNumber.ShouldBe("198600479406");
            profile.ForeignCompanyDetails.ShouldNotBeNull();
            profile.ForeignCompanyDetails!.AccountingRequirement!.ForeignAccountType.ShouldBe(
                ForeignAccountType.AccountingRequirementsOfOriginatingCountryApply);
            profile.ForeignCompanyDetails.AccountingRequirement!.TermsOfAccountPublication.ShouldBe(
                TermsOfAccountPublication.AccountsPublicationDateSuppliedByCompany);
            profile.ForeignCompanyDetails.Accounts!.AccountPeriodFrom!.Day.ShouldBe(1);
            profile.ForeignCompanyDetails.Accounts.AccountPeriodTo!.Month.ShouldBe(12);
            profile.ForeignCompanyDetails.Accounts.MustFileWithin!.Months.ShouldBe("12");
            profile.ForeignCompanyDetails.IsACreditFinancialInstitution.ShouldBe(true);
            profile.Links.UkEstablishments.ShouldBe("/company/FC040879/uk-establishments");
        }

        [Fact]
        public void CommunityInterestCompanyProfile_DeserializesSubtype()
        {
            var profile = JsonSerializer.Deserialize<CompanyProfile>(CommunityInterestCompanyJson, CompaniesHouseJsonSerializerOptions.Default);

            profile.ShouldNotBeNull();
            profile.CompanyNumber.ShouldBe("13507518");
            profile.IsCommunityInterestCompany.ShouldBe(true);
            profile.Subtype.ShouldBe(CompanySubtype.CommunityInterestCompany);
            profile.Type.ShouldBe(CompanyType.PrivateLimitedGuarantNsc);
        }

        private const string PlainCompanyJson = """
            {
              "accounts": {"accounting_reference_date": {"day": "26", "month": "02"}, "last_accounts": {"made_up_to": "2025-02-26", "period_end_on": "2025-02-26", "period_start_on": "2024-02-25", "type": "group"}, "next_accounts": {"due_on": "2026-08-26", "overdue": false, "period_end_on": "2026-02-26", "period_start_on": "2025-02-27"}, "next_due": "2026-08-26", "next_made_up_to": "2026-02-26", "overdue": false},
              "can_file": true, "company_name": "TESCO PLC", "company_number": "00445790", "company_status": "active",
              "confirmation_statement": {"last_made_up_to": "2026-06-18", "next_due": "2027-07-02", "next_made_up_to": "2027-06-18", "overdue": false},
              "date_of_creation": "1947-11-27", "etag": "80217136743211b43fe97348238217cf2539d2c9", "has_been_liquidated": false, "has_charges": false, "has_insolvency_history": false,
              "jurisdiction": "england-wales", "last_full_members_list_date": "2013-06-07",
              "links": {"self": "/company/00445790", "charges": "/company/00445790/charges", "filing_history": "/company/00445790/filing-history", "officers": "/company/00445790/officers", "exemptions": "/company/00445790/exemptions"},
              "previous_company_names": [{"ceased_on": "1983-08-25", "effective_from": "1981-12-14", "name": "TESCO STORES (HOLDINGS) PUBLIC LIMITED COMPANY"}, {"ceased_on": "1981-12-14", "effective_from": "1947-11-27", "name": "TESCO STORES (HOLDINGS) LIMITED"}],
              "registered_office_address": {"address_line_1": "Tesco House, Shire Park", "address_line_2": "Kestrel Way", "country": "United Kingdom", "locality": "Welwyn Garden City", "postal_code": "AL7 1GA"},
              "registered_office_is_in_dispute": false, "sic_codes": ["47110"], "type": "plc", "undeliverable_registered_office_address": false, "has_super_secure_pscs": false
            }
            """;

        private const string ForeignCompanyJson = """
            {
              "accounts": {"last_accounts": {"made_up_to": "2021-12-31", "period_end_on": "2021-12-31", "type": "null"}, "next_accounts": {"overdue": false, "period_end_on": "2022-12-31"}, "next_made_up_to": "2022-12-31", "overdue": false},
              "can_file": false, "company_name": "ABSA UK PERMANENT ESTABLISHMENT", "company_number": "FC040879", "company_status": "active",
              "date_of_creation": "2022-03-01", "etag": "185a52c646d2f03c05127df15915f784e41acf60",
              "external_registration_number": "198600479406",
              "foreign_company_details": {
                "accounting_requirement": {"foreign_account_type": "accounting-requirements-of-originating-country-apply", "terms_of_account_publication": "accounts-publication-date-supplied-by-company"},
                "accounts": {"account_period_from": {"day": "1", "month": "1"}, "account_period_to": {"day": "31", "month": "12"}, "must_file_within": {"months": "12"}},
                "business_activity": "Financial Services",
                "governed_by": "South African Companies Act 71 Of 2008, South African Banks Act 94 0f 1990",
                "is_a_credit_financial_institution": true,
                "originating_registry": {"country": "SOUTH AFRICA", "name": "Registered With Companies And Intellectural Property Commission"},
                "registration_number": "198600479406",
                "legal_form": "Limited And A Public Company"
              },
              "has_charges": false, "has_insolvency_history": false, "jurisdiction": "united-kingdom",
              "links": {"self": "/company/FC040879", "filing_history": "/company/FC040879/filing-history", "officers": "/company/FC040879/officers", "uk_establishments": "/company/FC040879/uk-establishments"},
              "registered_office_address": {"address_line_1": "Absa Towers West", "address_line_2": "15 Troye Street", "country": "South Africa", "locality": "Johannesburg", "region": "Gauteng 2000"},
              "registered_office_is_in_dispute": false, "type": "oversea-company", "undeliverable_registered_office_address": false, "has_super_secure_pscs": false
            }
            """;

        private const string CommunityInterestCompanyJson = """
            {
              "can_file": true,
              "company_name": "COMMUNITY INTEREST SAMPLE",
              "company_number": "13507518",
              "company_status": "active",
              "date_of_creation": "2021-07-15",
              "etag": "sample",
              "has_charges": false,
              "has_insolvency_history": false,
              "has_super_secure_pscs": false,
              "is_community_interest_company": true,
              "jurisdiction": "england-wales",
              "links": {"persons_with_significant_control": "/company/13507518/persons-with-significant-control", "persons_with_significant_control_statements": "/company/13507518/persons-with-significant-control-statements", "self": "/company/13507518", "filing_history": "/company/13507518/filing-history", "officers": "/company/13507518/officers"},
              "registered_office_address": {"address_line_1": "1 Example Street", "locality": "London", "postal_code": "SW1A 1AA"},
              "registered_office_is_in_dispute": false,
              "subtype": "community-interest-company",
              "type": "private-limited-guarant-nsc",
              "undeliverable_registered_office_address": false
            }
            """;
    }
}
