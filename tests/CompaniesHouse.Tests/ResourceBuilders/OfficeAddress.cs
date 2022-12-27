namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class OfficeAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }

        public string PoBox { get; set; }

        public string Premises { get; set; }

        public string Region { get; set; }
        
        public string Etag { get; set; }
        
        public string Kind { get; set; }
        
        public RegisteredOfficeAddressLinks Links { get; set; }
    }
    
    public class RegisteredOfficeAddressLinks
    {
        public string Self { get; set; }
    }
}