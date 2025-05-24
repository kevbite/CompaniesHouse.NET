using System.Linq;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyProfileResourceBuilder
    {
        private readonly CompanyProfile _companyProfile;

        public CompanyProfileResourceBuilder(CompanyProfile companyProfile)
        {
            _companyProfile = companyProfile;
        }



        public string Create()
        {
            return
                $@"{{
   ""accounts"": {{
      ""accounting_reference_date"" : {{
         ""day"" : {_companyProfile.Accounts.AccountingReferenceDate.Day},
         ""month"" : {_companyProfile.Accounts.AccountingReferenceDate.Month}
      }},
      ""last_accounts"" : {{
         ""made_up_to"" : ""{_companyProfile.Accounts.LastAccounts.MadeUpTo.ToString("yyyy-MM-dd")}"",
         ""type"" : ""{_companyProfile.Accounts.LastAccounts.Type}"",
         ""period_end_on"" : ""{_companyProfile.Accounts.LastAccounts.PeriodEndOn:yyyy-MM-dd}"",
         ""period_start_on"" : ""{_companyProfile.Accounts.LastAccounts.PeriodStartOn:yyyy-MM-dd}""
      }},
      ""next_accounts"": {{
         ""due_on"" : ""{_companyProfile.Accounts.NextAccounts.DueOn:yyyy-MM-dd}"",
         ""period_end_on"" : ""{_companyProfile.Accounts.NextAccounts.PeriodEndOn:yyyy-MM-dd}"",
         ""period_start_on"" : ""{_companyProfile.Accounts.NextAccounts.PeriodStartOn:yyyy-MM-dd}"",
         ""overdue"" : ""{_companyProfile.Accounts.NextAccounts.Overdue.ToString().ToLower()}""
      }},
      ""next_due"" : ""{_companyProfile.Accounts.NextDue.ToString("yyyy-MM-dd")}"",
      ""next_made_up_to"" : ""{_companyProfile.Accounts.NextMadeUpTo.ToString("yyyy-MM-dd")}"",
      ""overdue"" : {_companyProfile.Accounts.Overdue.ToString().ToLower()}
   }},
   ""annual_return"" : {{
      ""last_made_up_to"" : ""{_companyProfile.AnnualReturn.LastMadeUpTo.ToString("yyyy-MM-dd")}"",
      ""next_due"" : ""{_companyProfile.AnnualReturn.NextDue.ToString("yyyy-MM-dd")}"",
      ""next_made_up_to"" : ""{_companyProfile.AnnualReturn.NextMadeUpTo.ToString("yyyy-MM-dd")}"",
      ""overdue"" : {_companyProfile.AnnualReturn.Overdue.ToString().ToLower()}
   }},
    ""branch_company_details"" : {{
      ""business_activity"" : ""{_companyProfile.BranchCompanyDetails.BusinessActivity}"",
      ""parent_company_name"" : ""{_companyProfile.BranchCompanyDetails.ParentCompanyName}"",
      ""parent_company_number"" : ""{_companyProfile.BranchCompanyDetails.ParentCompanyNumber}""
   }},
   ""can_file"" : {_companyProfile.CanFile.ToString().ToLower()},
   ""company_name"" : ""{_companyProfile.CompanyName}"",
   ""company_number"" : ""{_companyProfile.CompanyNumber}"",
   ""company_status"" : ""{_companyProfile.CompanyStatus}"",
   ""company_status_detail"" : ""{_companyProfile.CompanyStatusDetail}"",
   ""confirmation_statement"" : {{
      ""last_made_up_to"" : ""{_companyProfile.ConfirmationStatement.LastMadeUpTo:yyyy-MM-dd}"",
      ""next_due"" : ""{_companyProfile.ConfirmationStatement.NextDue:yyyy-MM-dd}"",
      ""next_made_up_to"" : ""{_companyProfile.ConfirmationStatement.NextMadeUpTo:yyyy-MM-dd}"",
      ""overdue"" : ""{_companyProfile.ConfirmationStatement.Overdue.ToString().ToLower()}""
   }},
   ""date_of_creation"" : ""{_companyProfile.DateOfCreation.ToString("yyyy-MM-dd")}"",
   ""date_of_cessation"" : ""{_companyProfile.DateOfCessation.ToString("yyyy-MM-dd")}"",
   ""etag"" : ""{_companyProfile.ETag}"",
   ""has_been_liquidated"" : {_companyProfile.HasBeenLiquidated.ToString().ToLower()},
   ""has_charges"" : {_companyProfile.HasCharges.ToString().ToLower()},
   ""has_insolvency_history"" : {_companyProfile.HasInsolvencyHistory.ToString().ToLower()},
   ""is_community_interest_company"" : {_companyProfile.IsCommunityInterestCompany.ToString().ToLower()},
   ""jurisdiction"" : ""{_companyProfile.Jurisdiction}"",
   ""last_full_members_list_date"" : ""{_companyProfile.LastFullMembersListDate.ToString("yyyy-MM-dd")}"",
   ""links"" : {{
      ""charges"" : ""{_companyProfile.Links.Charges}"",
      ""filing_history"" : ""{_companyProfile.Links.FilingHistory}"",
      ""insolvency"" : ""{_companyProfile.Links.Insolvency}"",
      ""officers"" : ""{_companyProfile.Links.Officers}"",
      ""persons_with_significant_control"" : ""{_companyProfile.Links.PersonsWithSignificantControl}"",
      ""persons_with_significant_control_statements"" : ""{_companyProfile.Links.PersonsWithSignificantControlStatements}"",
      ""registers"" : ""{_companyProfile.Links.Registers}"",
      ""self"" : ""{_companyProfile.Links.Self}""
   }},
   ""officer_summary"" : {{
      ""active_count"" : {_companyProfile.OfficerSummary.ActiveCount},
      ""officers"" : [
        {string.Join(",", _companyProfile.OfficerSummary.Officers.Select(GetOfficerJsonBlock).ToArray())}
      ],
      ""resigned_count"" : {_companyProfile.OfficerSummary.ResignedCount}
   }},
   ""previous_company_names"" : [
      {string.Join(",", _companyProfile.PreviousCompanyNames.Select(GetPreviousCompanyNameJsonBlock).ToArray())}
   ],
   ""registered_office_address"" : {{
      ""address_line_1"" : ""{_companyProfile.RegisteredOfficeAddress.AddressLine1}"",
      ""address_line_2"" : ""{_companyProfile.RegisteredOfficeAddress.AddressLine2}"",
      ""care_of"" : ""{_companyProfile.RegisteredOfficeAddress.CareOf}"",
      ""country"" : ""{_companyProfile.RegisteredOfficeAddress.Country}"",
      ""locality"" : ""{_companyProfile.RegisteredOfficeAddress.Locality}"",
      ""po_box"" : ""{_companyProfile.RegisteredOfficeAddress.PoBox}"",
      ""postal_code"" : ""{_companyProfile.RegisteredOfficeAddress.PostalCode}"",
      ""premises"" : ""{_companyProfile.RegisteredOfficeAddress.Premises}"",
      ""region"" : ""{_companyProfile.RegisteredOfficeAddress.Region}""
   }},
   ""registered_office_is_in_dispute"" : {_companyProfile.RegisteredOfficeIsInDispute.ToString().ToLower()},
   ""sic_codes"" : [
      {string.Join(",", _companyProfile.SicCodes.Select(x => $@"""{x}"""))}
   ],
   ""type"" : ""{_companyProfile.Type}"",
   ""undeliverable_registered_office_address"" : {_companyProfile.UndeliverableRegisteredOfficeAddress.ToString().ToLower()},
   ""foreign_company_details"" : {{
        ""accounting_requirement"": {{
            ""foreign_account_type"": ""{_companyProfile.ForeignCompanyDetails.AccountingRequirement.ForeignAccountType}"",
            ""terms_of_account_publication"": ""{_companyProfile.ForeignCompanyDetails.AccountingRequirement.TermsOfAccountPublication}""
        }},
        ""accounts"": {{
            ""account_period_from:"": {{
                ""day"": ""{_companyProfile.ForeignCompanyDetails.Accounts.AccountPeriodFrom.Day}"",
                ""month"": ""{_companyProfile.ForeignCompanyDetails.Accounts.AccountPeriodFrom.Month}""
            }},
            ""account_period_to"": {{
                ""day"": ""{_companyProfile.ForeignCompanyDetails.Accounts.AccountPeriodTo.Day}"",
                ""month"": ""{_companyProfile.ForeignCompanyDetails.Accounts.AccountPeriodTo.Month}""
            }},
            ""must_file_within"": {{
                ""months"": ""{_companyProfile.ForeignCompanyDetails.Accounts.MustFileWithin.Months}"",
            }}
        }},
        ""business_activity"": ""{_companyProfile.ForeignCompanyDetails.BusinessActivity}"",
        ""company_type"": ""{_companyProfile.ForeignCompanyDetails.CompanyType}"",
        ""governed_by"": ""{_companyProfile.ForeignCompanyDetails.GovernedBy}"",
        ""is_a_credit_finance_institution"": {_companyProfile.ForeignCompanyDetails.IsACreditFinanceInstitution.ToString().ToLower()},
        ""originating_registry"": {{
            ""country"": ""{_companyProfile.ForeignCompanyDetails.OriginatingRegistry.Country}"",
            ""name"": ""{_companyProfile.ForeignCompanyDetails.OriginatingRegistry.Name}""
        }},
        ""registration_number"": ""{_companyProfile.ForeignCompanyDetails.RegistrationNumber}""
    }}
}}";
        }

        private object GetOfficerJsonBlock(Officer officer)
        {
            return $@" {{
            ""appointed_on"" : ""{officer.AppointedOn.ToString("yyyy-MM-dd")}"",
            ""resigned_on"" : ""{officer.ResignedOn.ToString("yyyy-MM-dd")}"",
            ""date_of_birth"" : {{
               ""day"" : {officer.DateOfBirth.Day},
               ""month"" : {officer.DateOfBirth.Month},
               ""year"" : {officer.DateOfBirth.Year}
            }},
            ""name"" : ""{officer.Name}"",
            ""officer_role"" : ""{officer.OfficerRole}""
         }}";
        }

        private string GetPreviousCompanyNameJsonBlock(PreviousCompanyName name)
        {
            return $@"{{
                ""name"" : ""{name.Name}"",
                ""ceased_on"" : ""{name.CeasedOn:yyyy-MM-dd}"",
                ""effective_from"" : ""{name.EffectiveFrom:yyyy-MM-dd}""
            }}";
        }
    }
}
