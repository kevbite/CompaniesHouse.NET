using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyProfile
    {
        public string Type { get; set; }

        public bool HasBeenLiquidated { get; set; }

        public RegisteredOfficeAddress RegisteredOfficeAddress { get; set; }

        public Accounts Accounts { get; set; }

        public AnnualReturn AnnualReturn { get; set; }

        public string Jurisdiction { get; set; }

        public string[] SicCodes { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfCessation { get; set; }

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

        public PreviousCompanyName[] PreviousCompanyNames { get; set; }

        public ConfirmationStatement ConfirmationStatement { get; set; }

        public bool CanFile { get; set; }

        public OfficerSummary OfficerSummary { get; set; }

        public bool RegisteredOfficeIsInDispute { get; set; }

        public CompanyProfileLinks Links { get; set; }

        public CompanyProfileBranchCompanyDetails BranchCompanyDetails { get; set; }
        
        public ForeignCompanyDetails ForeignCompanyDetails { get; set; }
    }
    
    public class ForeignCompanyDetails
    {
        public AccountingRequirement AccountingRequirement { get; set; }

        public ForeignCompanyAccounts Accounts { get; set; }

        public string BusinessActivity { get; set; }

        public string CompanyType { get; set; }

        public string GovernedBy { get; set; }

        public bool? IsACreditFinanceInstitution { get; set; }

        public OriginatingRegistry OriginatingRegistry { get; set; }

        public string RegistrationNumber { get; set; }
    }

    public class OriginatingRegistry
    {
        public string Country { get; set; }

        public string Name { get; set; }
    }

    public class ForeignCompanyAccounts
    {
        public ForeignCompanyPeriodFrom AccountPeriodFrom { get; set; }

        public ForeignCompanyPeriodTo AccountPeriodTo { get; set; }

        public MustFileWithin MustFileWithin { get; set; }

    }

    public class MustFileWithin
    {
        public int? Months { get; set; }
    }

    public class ForeignCompanyPeriodTo
    {
        public int? Day { get; set; }

        public int? Month { get; set; }
    }

    public class ForeignCompanyPeriodFrom
    {
        public int? Day { get; set; }

        public int? Month { get; set; }
    }

    public class AccountingRequirement
    {
        public string ForeignAccountType { get; set; }

        public string TermsOfAccountPublication { get; set; }
    }
}