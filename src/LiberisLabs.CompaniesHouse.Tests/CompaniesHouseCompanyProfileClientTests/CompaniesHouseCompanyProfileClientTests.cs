using System;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders;
using LiberisLabs.CompaniesHouse.UriBuilders;
using Moq;
using NUnit.Framework;
using CompanyProfile = LiberisLabs.CompaniesHouse.Response.CompanyProfile.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.Tests.CompaniesHouseCompanyProfileClientTests
{
    [TestFixture]
    public class CompaniesHouseCompanyProfileClientTests
    {
        private CompaniesHouseCompanyProfileClient _client;

        private CompaniesHouseClientResponse<CompanyProfile> _result;
        private ResourceBuilders.CompanyProfile _companyProfile;
        
        [TestCaseSource(nameof(TestCases))]
        public void GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile(CompaniesHouseCompanyProfileClientTestCase testCase)
        {
            _companyProfile = new CompanyProfileBuilder().Build(testCase);
            var resource = new CompanyProfileResourceBuilder(_companyProfile)
                                .Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateHttpClient())
                .Returns(new HttpClient(handler));
            
            var uriBuilder = new Mock<ICompanyProfileUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyProfileClient(httpClientFactory.Object, uriBuilder.Object);

            _result = _client.GetCompanyProfileAsync("abc").Result;

            _result.Data.ShouldBeEquivalentTo(_companyProfile);
        }


        public static CompaniesHouseCompanyProfileClientTestCase[] TestCases()
        {
            var a = from lastAccountsType in EnumerationMappings.PossibleLastAccountsTypes.Keys
                from companyStatus in EnumerationMappings.PossibleCompanyStatuses.Keys
                from companyStatusDetail in EnumerationMappings.PossibleCompanyStatusDetails.Keys
                from jurisdiction in EnumerationMappings.PossibleJurisdictions.Keys
                from type in EnumerationMappings.ExpectedCompanyTypesMap.Keys
                    select new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = lastAccountsType,
                    CompanyStatus = companyStatus,
                    CompanyStatusDetail = companyStatusDetail,
                    Jurisdiction = jurisdiction,
                    Type = type
                };

            return a.Take(1).ToArray();
        }

    }
}
