using CompaniesHouse.Response.PersonsWithSignificantControl;
using System;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Appointments;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonWithSignificantControl
    {
        public Address Address { get; set; } = null!;

        public DateTime CeasedOn { get; set; }

        public string CountryOfResidence { get; set; } = null!;

        public DateOfBirth DateOfBirth { get; set; } = null!;

        public string ETag { get; set; } = null!;

        public PersonWithSignificantControlKind Kind { get; set; }

        public PersonWithSignificantControlLinks Links { get; set; } = null!;

        public string Name { get; set; } = null!;

        public NameElements NameElements { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public PersonWithSignificantControlNatureOfControl[] NaturesOfControl { get; set; } = null!;

        public DateTime NotifiedOn { get; set; }

        public PersonWithSignificantControlIdentification Identification { get; set; } = null!;
    }
}