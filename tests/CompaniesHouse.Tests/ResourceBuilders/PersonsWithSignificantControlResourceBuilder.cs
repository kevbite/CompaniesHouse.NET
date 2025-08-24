﻿using CompaniesHouse.Response.PersonsWithSignificantControl;
using System.Linq;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonsWithSignificantControlResourceBuilder
    {
        private readonly PersonsWithSignificantControl _personsWithSignificantControl;

        public PersonsWithSignificantControlResourceBuilder(PersonsWithSignificantControl personsWithSignificantControl)
        {
            _personsWithSignificantControl = personsWithSignificantControl;
        }

        public string Create()
        {
            return
                $@"{{
                      ""active_count"" : {_personsWithSignificantControl.ActiveCount},
                      ""items"" : [
                        {string.Join(",", _personsWithSignificantControl.Items.Select(GetPersonWithSignificantControlJsonBlock).ToArray())}
                      ],
                      ""ceased_count"" : {_personsWithSignificantControl.CeasedCount},
                      ""items_per_page"" : {_personsWithSignificantControl.ItemsPerPage},
                      ""start_index"" : {_personsWithSignificantControl.StartIndex},
                      ""total_results"" : {_personsWithSignificantControl.TotalResults}
                }}";
        }

        private string GetPersonWithSignificantControlJsonBlock(PersonWithSignificantControl personWithSignificantControl)
        {
            return $@" {{
                    ""address"" : {{
                       ""address_line_1"" : ""{personWithSignificantControl.Address.AddressLine1}"",
                       ""address_line_2"" : ""{personWithSignificantControl.Address.AddressLine2}"",
                       ""care_of"" : ""{personWithSignificantControl.Address.CareOf}"",
                       ""country"" : ""{personWithSignificantControl.Address.Country}"",
                       ""locality"" : ""{personWithSignificantControl.Address.Locality}"",
                       ""po_box"" : ""{personWithSignificantControl.Address.PoBox}"",
                       ""postal_code"" : ""{personWithSignificantControl.Address.PostalCode}"",
                       ""premises"" : ""{personWithSignificantControl.Address.Premises}"",
                       ""region"" : ""{personWithSignificantControl.Address.Region}"",
                    }},
                    ""ceased_on"" : ""{personWithSignificantControl.CeasedOn.ToString("yyyy-MM-dd")}"",
                    ""country_of_residence"" : ""{personWithSignificantControl.CountryOfResidence}"",
                    ""date_of_birth"" : {{
                       ""day"" : {personWithSignificantControl.DateOfBirth.Day},
                       ""month"" : {personWithSignificantControl.DateOfBirth.Month},
                       ""year"" : {personWithSignificantControl.DateOfBirth.Year}
                    }},
                    ""etag"" : ""{personWithSignificantControl.ETag}"",
                    ""kind"" : ""{personWithSignificantControl.Kind}"",
                    ""links"" : {{
                        ""self"" : ""{personWithSignificantControl.Links.Self}"",
                        ""statement"" : ""{personWithSignificantControl.Links.Statement}"",
                    }},
                    ""name"" : ""{personWithSignificantControl.Name}"",
                    ""name_elements"" : {{
                        ""forename"" : ""{personWithSignificantControl.NameElements.Forename}"",
                        ""other_forenames"" : ""{personWithSignificantControl.NameElements.OtherForenames}"",
                        ""surname"" : ""{personWithSignificantControl.NameElements.Surname}"",
                        ""title"" : ""{personWithSignificantControl.NameElements.Title}"",
                    }},
                    ""nationality"" : ""{personWithSignificantControl.Nationality}"",
                    ""natures_of_control"" : [
                          {string.Join(",", personWithSignificantControl.NaturesOfControl.Select(GetPersonWithSignificantControlNatureOfControlsJsonBlock).ToArray())}
                    ],
                    ""notified_on"" : ""{personWithSignificantControl.NotifiedOn.ToString("yyyy-MM-dd")}"",
                    ""identification"": {GetPersonWithSignificantControlIdentificationJsonBlock(personWithSignificantControl.Identification)}
                 }}";
        }
        
        private static string GetPersonWithSignificantControlNatureOfControlsJsonBlock(PersonWithSignificantControlNatureOfControl natureOfControl)
        {
            return $@"""{natureOfControl}""";
        }

        private static string GetPersonWithSignificantControlIdentificationJsonBlock(PersonWithSignificantControlIdentification identification) =>
            $@"{{
      ""legal_authority"": ""{identification.LegalAuthority}"",
      ""legal_form"": ""{identification.LegalForm}"",
      ""place_registered"": ""{identification.PlaceRegistered}"",
      ""registration_number"": ""{identification.RegistrationNumber}"",
      ""country_registered"": ""{identification.CountryRegistered}"" 
}}";
    }
}