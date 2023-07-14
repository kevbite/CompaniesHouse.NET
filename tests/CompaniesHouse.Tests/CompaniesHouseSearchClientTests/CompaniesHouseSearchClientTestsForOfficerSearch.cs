using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;
using CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using AutoFixture;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    [TestFixture]
    public class CompaniesHouseSearchClientTestsForOfficerSearch
    {
        private CompaniesHouseSearchClient _client;
        private CompaniesHouseClientResponse<OfficerSearch> _result;
        private ResourceDetails _resourceDetails;
        
        [OneTimeSetUp]
        public async Task GivenACompanyHouseSearchClient_WhenSearchingForAOfficer()
        {
            var fixture = new Fixture();
            var items = fixture.Build<Item>()
                .With(x => x.Kind, "searchresults#officer")
                .CreateMany().ToArray();
            _resourceDetails = fixture.Build<ResourceDetails>()
                .With(x => x.Officers, items)
                .Create();
            
            var uri = new Uri("https://wibble.com/search/officers");

            var resource = new OfficerSearchResourceBuilder()
                .CreateResource(_resourceDetails);

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);


            _client = new CompaniesHouseSearchClient(new HttpClient(handler)
            {
                BaseAddress = new Uri("https://wibble.com/")
            }, new SearchUriBuilderFactory());

            _result = await _client.SearchAsync<SearchOfficerRequest, OfficerSearch>(new SearchOfficerRequest());
        }

        [Test]
        public void ThenResultDataIsCorrect()
        {
            _result.Data.ShouldBeEquivalentTo(_resourceDetails, opt => opt.Excluding(su => Regex.IsMatch(su.SelectedMemberPath, @"Officers\[.+\]\.OfficerId")));
        }  
    }
}
