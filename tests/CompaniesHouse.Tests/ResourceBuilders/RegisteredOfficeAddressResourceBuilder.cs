namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class RegisteredOfficeAddressResourceBuilder
    {
        private readonly OfficeAddress _officeAddress;

        public RegisteredOfficeAddressResourceBuilder(OfficeAddress officeAddress)
        {
            _officeAddress = officeAddress;
        }
        
        public string Create() =>
            @$"{{
                   ""address_line_1"" : ""{_officeAddress.AddressLine1}"",
                   ""address_line_2"" : ""{_officeAddress.AddressLine2}"",
                   ""country"" : ""{_officeAddress.Country}"",
                   ""locality"" : ""{_officeAddress.Locality}"",
                   ""po_box"" : ""{_officeAddress.PoBox}"",
                   ""postal_code"" : ""{_officeAddress.PostalCode}"",
                   ""premises"" : ""{_officeAddress.Premises}"",
                   ""region"" : ""{_officeAddress.Region}"",
                   ""etag"" : ""{_officeAddress.Etag}"",
                   ""kind"" : ""{_officeAddress.Kind}"",
                   ""links"" : {{
                        ""self"" : ""{_officeAddress.Links.Self}""
                   }}
               }}";
    }
}