using System;

namespace CompaniesHouse.Tests.ResourceBuilders.CompanySearchResource
{
    public class CompanyDetails
    {
        public string CompanyStatus { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string CareOf { get; set; }

        public string Country { get; set; }

        public string Locality { get; set; }

        public string PoBox { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string CompanyNumber { get; set; }

        public string CompanyType { get; set; }

        public DateTime DateOfCessation { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Description { get; set; }

        public string Kind { get; set; }

        public string LinksSelf { get; set; }

        public string Snippet { get; set; }

        public string Title { get; set; }

        public int[] MatchesTitle { get; set; }
    }
}