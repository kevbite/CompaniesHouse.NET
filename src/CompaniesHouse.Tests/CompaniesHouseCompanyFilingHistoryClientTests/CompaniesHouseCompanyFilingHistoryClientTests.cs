using System;
using System.Linq;
using System.Net.Http;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using CompanyFilingHistory = CompaniesHouse.Response.CompanyFiling.CompanyFilingHistory;

namespace CompaniesHouse.Tests.CompaniesHouseCompanyFilingHistoryClientTests
{
    [TestFixture]
    public class CompaniesHouseCompanyFilingHistoryClientTests
    {
        private CompaniesHouseCompanyFilingHistoryClient _client;

        private CompaniesHouseClientResponse<Response.CompanyFiling.CompanyFilingHistory> _result;
        private ResourceBuilders.CompanyFilingHistory _companyFilingHistory;

        [TestCaseSource(nameof(TestCases))]
        public void GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile(CompaniesHouseCompanyFilingHistoryClientTestCase testCase)
        {
            _companyFilingHistory = new CompanyFilingHistoryBuilder().Build(testCase);
            var resource = new CompanyFilingHistoryResourceBuilder(_companyFilingHistory)
                                .Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateHttpClient())
                .Returns(new HttpClient(handler));

            var uriBuilder = new Mock<ICompanyFilingHistoryUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyFilingHistoryClient(httpClientFactory.Object, uriBuilder.Object);

            _result = _client.GetCompanyFilingHistoryAsync("abc", 0, 25).Result;

            _result.Data.ShouldBeEquivalentTo(_companyFilingHistory);
        }


        public static CompaniesHouseCompanyFilingHistoryClientTestCase[] TestCases()
        {
            var allFilingCategories = EnumerationMappings.PossibleFilingCategories.Keys
                .Select(x => new CompaniesHouseCompanyFilingHistoryClientTestCase
                {
                    Category = x,
                    Subcategory = EnumerationMappings.PossibleFilingSubcategories.Keys.First(),
                    HistoryStatus = EnumerationMappings.PossibleFilingHistoryStatus.Keys.First(),
                    ResolutionCategory = EnumerationMappings.PossibleResolutionCategories.Keys.First()
                });

            var allFilingSubcategories = EnumerationMappings.PossibleFilingSubcategories.Keys
                .Select(x => new CompaniesHouseCompanyFilingHistoryClientTestCase
                {
                    Category = EnumerationMappings.PossibleFilingCategories.Keys.First(),
                    Subcategory = x,
                    HistoryStatus = EnumerationMappings.PossibleFilingHistoryStatus.Keys.First(),
                    ResolutionCategory = EnumerationMappings.PossibleResolutionCategories.Keys.First()
                });

            var allFilingHistoryStatus = EnumerationMappings.PossibleFilingHistoryStatus.Keys
                .Select(x => new CompaniesHouseCompanyFilingHistoryClientTestCase
                {
                    Category = EnumerationMappings.PossibleFilingCategories.Keys.First(),
                    Subcategory = EnumerationMappings.PossibleFilingSubcategories.Keys.First(),
                    HistoryStatus = x,
                    ResolutionCategory = EnumerationMappings.PossibleResolutionCategories.Keys.First()
                });

            var allFilingResolutionCategories = EnumerationMappings.PossibleResolutionCategories.Keys
                .Select(x => new CompaniesHouseCompanyFilingHistoryClientTestCase
                {
                    Category = EnumerationMappings.PossibleFilingCategories.Keys.First(),
                    Subcategory = EnumerationMappings.PossibleFilingSubcategories.Keys.First(),
                    HistoryStatus = EnumerationMappings.PossibleFilingHistoryStatus.Keys.First(),
                    ResolutionCategory = x
                });

            return allFilingCategories
                    .Concat(allFilingSubcategories)
                    .Concat(allFilingHistoryStatus)
                    .Concat(allFilingResolutionCategories)
                    .ToArray();
        }

    }
}
