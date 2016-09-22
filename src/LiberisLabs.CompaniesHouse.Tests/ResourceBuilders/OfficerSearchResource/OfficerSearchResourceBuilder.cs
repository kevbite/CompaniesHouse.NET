using System.Collections.Generic;
using System.Linq;

namespace LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource
{
    public class OfficerSearchResourceBuilder
    {
        public string CreateResource(ResourceDetails resourceDetails)
        {
            return $@"{{
  ""items_per_page"": {resourceDetails.ItemsPerPage},
  ""start_index"": {resourceDetails.StartIndex},
  ""page_number"": {resourceDetails.PageNumber},
  ""total_results"": {resourceDetails.TotalResults},
  ""items"": [
        {string.Join(", ", CreateItems(resourceDetails.Officers))}
    ],
  ""kind"": ""{resourceDetails.Kind}""
  }}";
        }

        private IEnumerable<string> CreateItems(Item[] items)
        {
            var items1 = new List<string>();
            foreach (var item in items)
            {
                var json = $@"{{
      ""description"": ""{item.Description}"",
      ""snippet"": ""{item.Snippet}"",
      ""date_of_birth"": {{
        ""year"": {item.DateOfBirth.Year},
        ""month"": {item.DateOfBirth.Month}
      }},
      ""address_snippet"": ""{item.AddressSnippet}"",
      ""address"": {{
        ""address_line_1"" : ""{item.Address.AddressLine1}"",
        ""address_line_2"" : ""{item.Address.AddressLine2}"",
        ""care_of"" : ""{item.Address.CareOf}"",
        ""country"" : ""{item.Address.Country}"",
        ""locality"" : ""{item.Address.Locality}"",
        ""po_box"" : ""{item.Address.PoBox}"",
        ""postal_code"" : ""{item.Address.PostalCode}"",
        ""premises"" : ""{item.Address.Premises}"",
        ""region"" : ""{item.Address.Region}""
      }},
      ""description_identifiers"": [
        {string.Join(", ", item.DescriptionIdentifiers.Select(x => $@"""{x}""" ))}
      ],
      ""appointment_count"": {item.AppointmentCount},
      ""links"": {{
        ""self"": ""{item.Links.Self}""
      }},
      ""title"": ""{item.Title}"",
      ""matches"": {{
        ""snippet"": [{string.Join(",", item.Matches.Snippet)}],
        ""title"": [{string.Join(",", item.Matches.Title)}],
        ""address_snippet"": [{string.Join(",", item.Matches.AddressSnippet)}]
      }},
      ""kind"": ""{item.Kind}""
    }}";

                items1.Add(json);
            }

            return items1;
        }
    }
}