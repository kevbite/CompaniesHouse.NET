using System;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Officers;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Officer
    {
        public DateTime AppointedOn { get; set; }

        public DateTime ResignedOn { get; set; }

        public DateOfBirth DateOfBirth { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string OfficerRole { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public string Occupation { get; set; } = null!;

        public Address Address { get; set; } = null!;

        public string CountryOfResidence { get; set; } = null!;

        public OfficerFormerName[] FormerNames { get; set; } = null!;

        public OfficerIdentification Identification { get; set; } = null!;

        public OfficerLinks Links { get; set; } = null!;
    }
}