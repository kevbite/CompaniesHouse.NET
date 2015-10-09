using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.UriBuilders;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace LiberisLabs.CompaniesHouse.Tests
{
    [TestFixture]
    public class CompanyHouseSearchCompanyClientTests
    {
        private CompanyHouseSearchCompanyClient _client;
        private CompanySearch _companySearch;
        private CompaniesHouseClientResponse<CompanySearch> _result;

        [TestFixtureSetUp]
        public void GivenACompanyHouseSearchCompanyClient_WhenSearchingForACompany()
        {
            _companySearch = new Fixture().Create<CompanySearch>();
            var uri = new Uri("https://wibble.com/search/companies");
            Func<HttpMessageHandler> handler = () => new StubHttpMessageHandler(uri, new CompanySearchResourceBuilder().CreateResource(_companySearch));
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateHttpClient())
                .Returns(new HttpClient(handler()));

            var uriBuilder = new Mock<ICompanySearchUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<CompanySearchRequest>()))
                .Returns(uri);

            _client = new CompanyHouseSearchCompanyClient(httpClientFactory.Object, uriBuilder.Object);

            _result = _client.SearchCompany(new CompanySearchRequest()).Result;
        }

        [Test]
        public void ThenTheRootIsCorrect()
        {
            Assert.That(_result.Data.ETag, Is.EqualTo(_companySearch.ETag));
            Assert.That(_result.Data.ItemsPerPage, Is.EqualTo(_companySearch.ItemsPerPage));
            Assert.That(_result.Data.Kind, Is.EqualTo(_companySearch.Kind));
            Assert.That(_result.Data.PageNumber, Is.EqualTo(_companySearch.PageNumber));
            Assert.That(_result.Data.StartIndex, Is.EqualTo(_companySearch.StartIndex));
            Assert.That(_result.Data.TotalResults, Is.EqualTo(_companySearch.TotalResults));
        }

        [Test]
        public void ThenTheCompanyResultsAreCorrect()
        {
            Assert.That(_result.Data.Companies.Count(), Is.EqualTo(_companySearch.Companies.Count()));

            foreach (var company in _result.Data.Companies)
            {
                var actualCompany = _companySearch.Companies.FirstOrDefault(x => x.CompanyNumber == company.CompanyNumber);

                Assert.That(actualCompany.Address.AddressLine1, Is.EqualTo(actualCompany.Address.AddressLine1));
                Assert.That(actualCompany.Address.AddressLine2, Is.EqualTo(actualCompany.Address.AddressLine2));
                Assert.That(actualCompany.Address.CareOf, Is.EqualTo(actualCompany.Address.CareOf));
                Assert.That(actualCompany.Address.Country, Is.EqualTo(actualCompany.Address.Country));
                Assert.That(actualCompany.Address.Locality, Is.EqualTo(actualCompany.Address.Locality));
                Assert.That(actualCompany.Address.PoBox, Is.EqualTo(actualCompany.Address.PoBox));
                Assert.That(actualCompany.Address.PostalCode, Is.EqualTo(actualCompany.Address.PostalCode));
                Assert.That(actualCompany.Address.Region, Is.EqualTo(actualCompany.Address.Region));

                Assert.That(actualCompany.CompanyStatus, Is.EqualTo(actualCompany.CompanyStatus));
                Assert.That(actualCompany.CompanyType, Is.EqualTo(actualCompany.CompanyType));
                Assert.That(actualCompany.DateOfCessation, Is.EqualTo(actualCompany.DateOfCessation));
                Assert.That(actualCompany.DateOfCreation, Is.EqualTo(actualCompany.DateOfCreation));
                Assert.That(actualCompany.Description, Is.EqualTo(actualCompany.Description));
                Assert.That(actualCompany.DescriptionIdentifier, Is.EqualTo(actualCompany.DescriptionIdentifier));
                Assert.That(actualCompany.Kind, Is.EqualTo(actualCompany.Kind));
                Assert.That(actualCompany.Links.Self, Is.EqualTo(actualCompany.Links.Self));
                Assert.That(actualCompany.Matches.Title, Is.EqualTo(actualCompany.Matches.Title));
                Assert.That(actualCompany.Snippet, Is.EqualTo(actualCompany.Snippet));
                Assert.That(actualCompany.Title, Is.EqualTo(actualCompany.Title));

            }
        }
    }

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
   ""items_per_page"" : ""{companySearch.ItemsPerPage}"",
   ""kind"" : ""{companySearch.Kind}"",
   ""page_number"" : ""{companySearch.PageNumber}"",
   ""start_index"" : ""{companySearch.StartIndex}"",
   ""total_results"" : ""{companySearch.TotalResults}""
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
