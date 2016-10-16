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
         ""type"" : ""{_companyProfile.Accounts.LastAccounts.Type}""
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
   ""date_of_dissolution"" : ""{_companyProfile.DateOfDissolution.ToString("yyyy-MM-dd")}"",
   ""etag"" : ""{_companyProfile.ETag}"",
   ""has_been_liquidated"" : {_companyProfile.HasBeenLiquidated.ToString().ToLower()},
   ""has_charges"" : {_companyProfile.HasCharges.ToString().ToLower()},
   ""has_insolvency_history"" : {_companyProfile.HasInsolvencyHistory.ToString().ToLower()},
   ""is_community_interest_company"" : {_companyProfile.IsCommunityInterestCompany.ToString().ToLower()},
   ""jurisdiction"" : ""{_companyProfile.Jurisdiction}"",
   ""last_full_members_list_date"" : ""{_companyProfile.LastFullMembersListDate.ToString("yyyy-MM-dd")}"",
   ""officer_summary"" : {{
      ""active_count"" : {_companyProfile.OfficerSummary.ActiveCount},
      ""officers"" : [
        {string.Join(",", _companyProfile.OfficerSummary.Officers.Select(GetOfficerJsonBlock).ToArray())}
      ],
      ""resigned_count"" : {_companyProfile.OfficerSummary.ResignedCount}
   }},
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
   ""undeliverable_registered_office_address"" : {_companyProfile.UndeliverableRegisteredOfficeAddress.ToString().ToLower()}
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
    }
}
