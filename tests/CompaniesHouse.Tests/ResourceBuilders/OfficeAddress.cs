namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class OfficeAddress
    {
        public string AddressLine1 { get; set; } = null!;

        public string AddressLine2 { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Locality { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string PoBox { get; set; } = null!;

        public string Premises { get; set; } = null!;

        public string Region { get; set; } = null!;
        
        public string Etag { get; set; } = null!;
        
        public string Kind { get; set; } = null!;
        
        public RegisteredOfficeAddressLinks Links { get; set; } = null!;
    }
    
    public class RegisteredOfficeAddressLinks
    {
        public string Self { get; set; } = null!;
    }
}