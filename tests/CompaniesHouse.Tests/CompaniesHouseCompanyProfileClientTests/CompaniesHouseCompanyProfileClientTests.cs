using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;
using CompanyProfile = CompaniesHouse.Response.CompanyProfile.CompanyProfile;

namespace CompaniesHouse.Tests.CompaniesHouseCompanyProfileClientTests
{
    public class CompaniesHouseCompanyProfileClientTests
    {
        private CompaniesHouseCompanyProfileClient _client;

        private CompaniesHouseClientResponse<Response.CompanyProfile.CompanyProfile> _result;
        private ResourceBuilders.CompanyProfile _companyProfile;

        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile(CompaniesHouseCompanyProfileClientTestCase testCase)
        {
            _companyProfile = new CompanyProfileBuilder().Build(testCase);
            var resource = new CompanyProfileResourceBuilder(_companyProfile)
                                .Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<ICompanyProfileUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyProfileClient(new HttpClient(handler), uriBuilder.Object);

            _result = await _client.GetCompanyProfileAsync("abc");

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _companyProfile);
        }


        public static IEnumerable<object[]> TestCases()
        {
            var allLastAccountsTypes = EnumerationMappings.PossibleLastAccountsTypes.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = x,
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allCompanyStatuses = EnumerationMappings.PossibleCompanyStatuses.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = x,
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allCompanyStatusDetails = EnumerationMappings.PossibleCompanyStatusDetails.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = x,
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allJurisdictions = EnumerationMappings.PossibleJurisdictions.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = x,
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allCompanyTypes = EnumerationMappings.ExpectedCompanyTypesMap.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = x
                });

            return allLastAccountsTypes.Concat(allCompanyStatuses)
                .Concat(allCompanyStatusDetails)
                .Concat(allJurisdictions)
                .Concat(allCompanyTypes)
                .Select(testCase => new object[] { testCase });
        }

    }
}
