using System.Collections.Generic;

namespace LiberisLabs.CompaniesHouse.Tests
{
    public class CompanySearchResourceBuilder
    {
        private readonly List<string> _itemBlocks = new List<string>();
        
        public string CreateResource(ResourceDetails companySearch)
        {
            var resource =
                $@"{{
   ""etag"": ""{companySearch.ETag}"",
   ""items"" : [
      {string.Join(", ", _itemBlocks)}
   ],
   ""items_per_page"" : {companySearch.ItemsPerPage},
   ""kind"" : ""{companySearch.Kind}"",
   ""page_number"" : {companySearch.PageNumber},
   ""start_index"" : {companySearch.StartIndex},
   ""total_results"" : {companySearch.TotalResults}
}}";
            return resource;
        }

        public CompanySearchResourceBuilder AddCompanies(IEnumerable<CompanyDetails> companiesDetails)
        {
            foreach (var companyDetails in companiesDetails)
            {
                AddCompany(companyDetails);
            }

            return this;
        }

        public CompanySearchResourceBuilder AddCompany(CompanyDetails companyDetails)
        {
            var itemBlock = 
                $@" {{
         ""address"": {{
            ""address_line_1"" : ""{companyDetails.AddressLine1}"",
            ""address_line_2"" : ""{companyDetails.AddressLine2}"",
            ""care_of"" : ""{companyDetails.CareOf}"",
            ""country"" : ""{companyDetails.Country}"",
            ""locality"" : ""{companyDetails.Locality}"",
            ""po_box"" : ""{companyDetails.PoBox}"",
            ""postal_code"" : ""{companyDetails.PostalCode}"",
            ""region"" : ""{companyDetails.Region}""
         }},
         ""company_number"" : ""{companyDetails.CompanyNumber}"",
         ""company_status"" : ""{companyDetails.CompanyStatus}"",
         ""company_type"" : ""{companyDetails.CompanyType}"",
         ""date_of_cessation"" : ""{companyDetails.DateOfCessation}"",
         ""date_of_creation"" : ""{companyDetails.DateOfCreation}"",
         ""description"" : ""{companyDetails.Description}"",
         ""description_identifier"" : [
            null
         ],
         ""kind"" : ""{companyDetails.Kind}"",
         ""links"" : {{
            ""self"" : ""{companyDetails.LinksSelf}""
         }},
         ""matches"" : {{
            ""title"" : [
               {string.Join(", ",companyDetails.MatchesTitle)}
            ]
    }},
         ""snippet"" : ""{companyDetails.Snippet}"",
         ""title"" : ""{companyDetails.Title}""
      }}";
            _itemBlocks.Add(itemBlock);
            
            return this;
        }
    }
}