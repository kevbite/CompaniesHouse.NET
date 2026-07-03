using System;

namespace CompaniesHouse.Tests.ResourceBuilders.CompanySearchResource
{
    public class CompanyDetails
    {
        public string CompanyStatus { get; set; } = null!;

        public string AddressLine1 { get; set; } = null!;

        public string AddressLine2 { get; set; } = null!;

        public string CareOf { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Locality { get; set; } = null!;

        public string PoBox { get; set; } = null!;

        public string Region { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string CompanyNumber { get; set; } = null!;

        public string CompanyType { get; set; } = null!;

        public string AddressSnippet { get; set; } = null!;

        public DateTime DateOfCessation { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Description { get; set; } = null!;

        public string ExternalRegistrationNumber { get; set; } = null!;

        public string Kind { get; set; } = null!;

        public string LinksSelf { get; set; } = null!;

        public string Snippet { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int[] MatchesSnippet { get; set; } = null!;

        public int[] MatchesTitle { get; set; } = null!;
    }
}