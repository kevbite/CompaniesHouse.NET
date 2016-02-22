using System;
using System.Linq;

namespace LiberisLabs.CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyProfile
    {
        public bool HasBeenLiquidated { get; set; }
        public RegisteredOfficeAddress RegisteredOfficeAddress { get; set; }
        public Accounts Accounts { get; set; }
        public string Type { get; set; }
        public AnnualReturn AnnualReturn { get; set; }
        public string Jurisdiction { get; set; }
        public string[] SicCodes { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfDissolution { get; set; }
        public bool UndeliverableRegisteredOfficeAddress { get; set; }
        public DateTime LastFullMembersListDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string ETag { get; set; }
        public string CompanyStatus { get; set; }
        public string CompanyStatusDetail { get; set; }
        public bool HasInsolvencyHistory { get; set; }
        public bool IsCommunityInterestCompany { get; set; }
        public bool HasCharges { get; set; }
        public PreviousCompanyNames[] PreviousCompanyNames { get; set; }
        public bool CanFile { get; set; }
        public OfficerSummary OfficerSummary { get; set; }

        public bool RegisteredOfficeIsInDispute { get; set; }
    }

    public class OfficerSummary
    {
        public string ActiveCount { get; set; }
        public Officer[] Officers { get; set; }
        public string ResignedCount { get; set; }
    }

    public class Officer
    {
        public DateTime AppointedOn { get; set; }
        public DateOfBirth DateOfBirth { get; set; }
        public string Name { get; set; }
        public string OfficerRole { get; set; }
    }

    public class DateOfBirth
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }


    public class RegisteredOfficeAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public string Locality { get; set; }
        public string CareOf { get; set; }
        public string Country { get; set; }
        public string PoBox { get; set; }
        public string Premises { get; set; }
        public string Region { get; set; }
    }

    public class Accounts
    {
        public DateTime NextDue { get; set; }

        public AccountingReferenceDate AccountingReferenceDate { get; set; }

        public LastAccounts LastAccounts { get; set; }

        public DateTime NextMadeUpTo { get; set; }

        public bool Overdue { get; set; }
    }

    public class PreviousCompanyNames
    {
        public string CeasedOn { get; set; }
        public string Name { get; set; }
        public string EffectiveFrom { get; set; }
    }


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
      ""overdue"" : {_companyProfile.Accounts.Overdue}
   }},
   ""annual_return"" : {{
      ""last_made_up_to"" : ""{_companyProfile.AnnualReturn.LastMadeUpTo.ToString("yyyy-MM-dd")}"",
      ""next_due"" : ""{_companyProfile.AnnualReturn.NextDue.ToString("yyyy-MM-dd")}"",
      ""next_made_up_to"" : ""{_companyProfile.AnnualReturn.NextMadeUpTo.ToString("yyyy-MM-dd")}"",
      ""overdue"" : {_companyProfile.AnnualReturn.Overdue}
   }},
   ""can_file"" : {_companyProfile.CanFile},
   ""company_name"" : ""{_companyProfile.CompanyName}"",
   ""company_number"" : ""{_companyProfile.CompanyNumber}"",
   ""company_status"" : ""{_companyProfile.CompanyStatus}"",
   ""company_status_detail"" : ""{_companyProfile.CompanyStatusDetail}"",
   ""date_of_creation"" : ""{_companyProfile.DateOfCreation.ToString("yyyy-MM-dd")}"",
   ""date_of_dissolution"" : ""{_companyProfile.DateOfDissolution.ToString("yyyy-MM-dd")}"",
   ""etag"" : ""{_companyProfile.ETag}"",
   ""has_been_liquidated"" : {_companyProfile.HasBeenLiquidated},
   ""has_charges"" : {_companyProfile.HasCharges},
   ""has_insolvency_history"" : {_companyProfile.HasInsolvencyHistory},
   ""is_community_interest_company"" : {_companyProfile.IsCommunityInterestCompany},
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
   ""registered_office_is_in_dispute"" : {_companyProfile.RegisteredOfficeIsInDispute},
   ""sic_codes"" : [
      {string.Join(",", _companyProfile.SicCodes.Select(x => $@"""{x}"""))}
   ],
   ""type"" : ""{_companyProfile.Type}"",
   ""undeliverable_registered_office_address"" : {_companyProfile.UndeliverableRegisteredOfficeAddress}
}}";
        }

        private object GetOfficerJsonBlock(Officer officer)
        {
            return $@" {{
            ""appointed_on"" : ""{officer.AppointedOn.ToString("yyyy-MM-dd")}"",
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
