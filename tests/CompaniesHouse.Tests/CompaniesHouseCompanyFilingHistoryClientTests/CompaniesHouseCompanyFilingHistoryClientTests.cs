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

namespace CompaniesHouse.Tests.CompaniesHouseCompanyFilingHistoryClientTests
{
    public class CompaniesHouseCompanyFilingHistoryClientTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile(CompaniesHouseCompanyFilingHistoryClientTestCase testCase)
        {
            var companyFilingHistory = CompanyFilingHistoryBuilder.Build(testCase);
            var resource = new CompanyFilingHistoryResourceBuilder(companyFilingHistory)
                .Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<ICompanyFilingHistoryUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(uri);

            var client = new CompaniesHouseCompanyFilingHistoryClient(new HttpClient(handler), uriBuilder.Object);

            var result = await client.GetCompanyFilingHistoryAsync("abc", 0, 25);

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, companyFilingHistory);
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseCompanyFilingHistoryClient_WhenGettingAFilingHistoryItem(CompaniesHouseCompanyFilingHistoryClientTestCase testCase)
        {
            var filingHistory = CompanyFilingHistoryBuilder.BuildOne(testCase);
            var resource = CompanyFilingHistoryResourceBuilder.CreateOne(filingHistory);

            var uri = new Uri("https://wibble.com/company/1/filing-history/1");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<ICompanyFilingHistoryUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseCompanyFilingHistoryClient(new HttpClient(handler), uriBuilder.Object);

            var result = await client.GetFilingHistoryByTransactionAsync("abc", "id1");

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, filingHistory);
        }

        public static IEnumerable<object[]> TestCases()
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
                .Select(testCase => new object[] { testCase });
        }
    }
}