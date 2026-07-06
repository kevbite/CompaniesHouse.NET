using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyProfile
    {
        public string Type { get; set; } = null!;

        public bool HasBeenLiquidated { get; set; }

        public RegisteredOfficeAddress RegisteredOfficeAddress { get; set; } = null!;

        public Accounts Accounts { get; set; } = null!;

        public AnnualReturn AnnualReturn { get; set; } = null!;

        public string Jurisdiction { get; set; } = null!;

        public string[] SicCodes { get; set; } = null!;

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfCessation { get; set; }

        public bool UndeliverableRegisteredOfficeAddress { get; set; }

        public DateTime LastFullMembersListDate { get; set; }

        public string CompanyName { get; set; } = null!;

        public string CompanyNumber { get; set; } = null!;

        public string ETag { get; set; } = null!;

        public string CompanyStatus { get; set; } = null!;

        public string CompanyStatusDetail { get; set; } = null!;

        public bool HasInsolvencyHistory { get; set; }

        public bool IsCommunityInterestCompany { get; set; }

        public bool HasCharges { get; set; }

        public PreviousCompanyName[] PreviousCompanyNames { get; set; } = null!;

        public ConfirmationStatement ConfirmationStatement { get; set; } = null!;

        public bool CanFile { get; set; }

        public OfficerSummary OfficerSummary { get; set; } = null!;

        public bool RegisteredOfficeIsInDispute { get; set; }

        public CompanyProfileLinks Links { get; set; } = null!;

        public CompanyProfileBranchCompanyDetails BranchCompanyDetails { get; set; } = null!;
    }
}