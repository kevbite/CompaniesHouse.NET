using System.Linq;
using CompaniesHouse.Response.Officers;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class OfficersResourceBuilder
    {
        private readonly Officers _officers;

        public OfficersResourceBuilder(Officers officers)
        {
            _officers = officers;
        }

        public string Create()
        {
            return
                $@"{{
                      ""active_count"" : {_officers.ActiveCount},
                      ""items"" : [
                        {string.Join(",", _officers.Items.Select(CreateSingle).ToArray())}
                      ],
                      ""resigned_count"" : {_officers.ResignedCount},
                      ""total_results"" : {_officers.TotalResults},
                      ""start_index"" : {_officers.StartIndex},
                }}";
        }

        public static string CreateSingle(Officer officer)
        {
            return $@" {{
                    ""appointed_on"" : ""{officer.AppointedOn.ToString("yyyy-MM-dd")}"",
                    ""resigned_on"" : ""{officer.ResignedOn.ToString("yyyy-MM-dd")}"",
                    ""date_of_birth"" : {{
                       ""day"" : {officer.DateOfBirth.Day},
                       ""month"" : {officer.DateOfBirth.Month},
                       ""year"" : {officer.DateOfBirth.Year}
                    }},
                    ""links"" : {{
                        ""officer"" : {{
                            ""appointments"" : ""{officer.Links.Officer.AppointmentsResource}""                                                               
                            }}                    
                    }},
                    ""name"" : ""{officer.Name}"",
                    ""officer_role"" : ""{officer.OfficerRole}"",
                    ""nationality"" : ""{officer.Nationality}"",
                    ""occupation"" : ""{officer.Occupation}"",
                    ""address"" : {{
                       ""address_line_1"" : ""{officer.Address.AddressLine1}"",
                       ""address_line_2"" : ""{officer.Address.AddressLine2}"",
                       ""care_of"" : ""{officer.Address.CareOf}"",
                       ""country"" : ""{officer.Address.Country}"",
                       ""locality"" : ""{officer.Address.Locality}"",
                       ""po_box"" : ""{officer.Address.PoBox}"",
                       ""postal_code"" : ""{officer.Address.PostalCode}"",
                       ""premises"" : ""{officer.Address.Premises}"",
                       ""region"" : ""{officer.Address.Region}"",
                    }},
                    ""country_of_residence"" : ""{officer.CountryOfResidence}"",
                    ""former_names"" : [
                        {string.Join(",", officer.FormerNames.Select(GetOfficerFormerNameJsonBlock).ToArray())}
                    ],
                    ""identification"": {{
                        ""identification_type"": ""{officer.Identification.IdentificationType}"",
                        ""legal_authority"": ""{officer.Identification.LegalAuthority}"",
                        ""legal_form"": ""{officer.Identification.LegalForm}"",
                        ""place_registered"": ""{officer.Identification.PlaceRegistered}"",
                        ""registration_number"": ""{officer.Identification.RegistrationNumber}""
                    }}
                 }}";
        }

        private static string GetOfficerFormerNameJsonBlock(OfficerFormerName officerFormerName)
        {
            return $@"{{
                    ""forenames"": ""{officerFormerName.ForeNames}"",
                    ""surname"": ""{officerFormerName.Surname}""
            }}";
        }
    }
}