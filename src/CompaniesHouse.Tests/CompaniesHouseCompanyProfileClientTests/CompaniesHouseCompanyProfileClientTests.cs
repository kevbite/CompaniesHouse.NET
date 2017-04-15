using System;
using System.Linq;
using System.Net.Http;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using CompanyProfile = CompaniesHouse.Response.CompanyProfile.CompanyProfile;

namespace CompaniesHouse.Tests.CompaniesHouseCompanyProfileClientTests
{
    [TestFixture]
    public class CompaniesHouseCompanyProfileClientTests
    {
        private CompaniesHouseCompanyProfileClient _client;

        private CompaniesHouseClientResponse<Response.CompanyProfile.CompanyProfile> _result;
        private ResourceBuilders.CompanyProfile _companyProfile;

        [TestCaseSource(nameof(TestCases))]
        public void GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile(CompaniesHouseCompanyProfileClientTestCase testCase)
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

            _result = _client.GetCompanyProfileAsync("abc").Result;

            _result.Data.ShouldBeEquivalentTo(_companyProfile);
        }


        public static CompaniesHouseCompanyProfileClientTestCase[] TestCases()
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
                .ToArray();
        }

    }
}
