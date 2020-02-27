using System;
using CompaniesHouse.Core.Response;
using CompaniesHouse.Core.Response.Officers;

namespace CompaniesHouse.Core.Tests.ResourceBuilders
{
    public class Officer
    {
        public DateTime AppointedOn { get; set; }

        public DateTime ResignedOn { get; set; }

        public DateOfBirth DateOfBirth { get; set; }

        public string Name { get; set; }

        public string OfficerRole { get; set; }

        public string Nationality { get; set; }

        public string Occupation { get; set; }

        public Address Address { get; set; }

        public string CountryOfResidence { get; set; }

        public OfficerFormerName[] FormerNames { get; set; }

        public OfficerIdentification Identification { get; set; }

        public OfficerLinks Links { get; set; }
        public string OfficerId
        {
            get { return Links.Officer.OfficerId; }
        }
    }
}