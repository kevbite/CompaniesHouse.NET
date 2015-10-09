using System.Collections.Generic;
using System.Linq;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;

namespace LiberisLabs.CompaniesHouse.Tests
{
    public class CompanySearchResourceBuilder
    {

        public string CreateResource(CompanySearch companySearch)
        {
            var itemsBlock = CreateItemsBlock(companySearch.Companies);

            var resource =
                $@"{{
   ""etag"": ""{companySearch.ETag}"",
   ""items"" : [
      {string.Join(", ", itemsBlock)}
   ],
   ""items_per_page"" : {companySearch.ItemsPerPage},
   ""kind"" : ""{companySearch.Kind}"",
   ""page_number"" : {companySearch.PageNumber},
   ""start_index"" : {companySearch.StartIndex},
   ""total_results"" : {companySearch.TotalResults}
}}";
            return resource;
        }

        private static IEnumerable<string> CreateItemsBlock(IEnumerable<Company> companies)
        {
            var itemsBlock = companies.Select(c =>
                $@" {{
         ""address"": {{
            ""address_line_1"" : ""{c.Address.AddressLine1}"",
            ""address_line_2"" : ""{c.Address.AddressLine2}"",
            ""care_of"" : ""{c.Address.CareOf}"",
            ""country"" : ""{c.Address.Country}"",
            ""locality"" : ""{c.Address.Locality}"",
            ""po_box"" : ""{c.Address.PoBox}"",
            ""postal_code"" : ""{c.Address.PostalCode}"",
            ""region"" : ""{c.Address.Region}""
         }},
         ""company_number"" : ""{c.CompanyNumber}"",
         ""company_status"" : ""{c.CompanyStatus}"",
         ""company_type"" : ""{c.CompanyType}"",
         ""date_of_cessation"" : ""{c.DateOfCessation}"",
         ""date_of_creation"" : ""{c.DateOfCreation}"",
         ""description"" : ""{c.Description}"",
         ""description_identifier"" : [
            null
         ],
         ""kind"" : ""{c.Kind}"",
         ""links"" : {{
            ""self"" : ""{c.Links.Self}""
         }},
         ""matches"" : {{
            ""title"" : [
               null
            ]
    }},
         ""snippet"" : ""{c.Snippet}"",
         ""title"" : ""{c.Title}""
      }}");

            return itemsBlock;
        }
    }
}