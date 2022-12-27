using CompaniesHouse.Response.PersonsWithSignificantControl;
using System;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Appointments;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonWithSignificantControl
    {
        public Address Address { get; set; }

        public DateTime CeasedOn { get; set; }

        public string CountryOfResidence { get; set; }

        public DateOfBirth DateOfBirth { get; set; }

        public string ETag { get; set; }

        public PersonWithSignificantControlKind Kind { get; set; }

        public PersonWithSignificantControlLinks Links { get; set; }

        public string Name { get; set; }

        public NameElements NameElements { get; set; }

        public string Nationality { get; set; }

        public PersonWithSignificantControlNatureOfControl[] NaturesOfControl { get; set; }

        public DateTime NotifiedOn { get; set; }

        public PersonWithSignificantControlIdentification Identification { get; set; }
    }
}