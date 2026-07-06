using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyFiling;
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

        [Fact]
        public async Task GivenARealCapturedMortgageFiling_WhenGettingAFilingHistoryItem_ThenSingleSubcategoryAndActionDateDeserialize()
        {
            const string json = """
                {
                  "transaction_id":"MzUyMDQ1NzU4MWFkaXF6a2N4",
                  "barcode":"XF1MYMJM",
                  "type":"MR01",
                  "date":"2026-05-08",
                  "category":"mortgage",
                  "subcategory":"create",
                  "description":"mortgage-create-with-deed-with-charge-number-charge-creation-date",
                  "description_values":{"charge_number":"000020650090","charge_creation_date":"2026-05-06"},
                  "pages":16,
                  "action_date":"2026-05-06",
                  "links":{"self":"/company/00002065/filing-history/MzUyMDQ1NzU4MWFkaXF6a2N4","document_metadata":"https://document-api.company-information.service.gov.uk/document/yiC6UOsmY5UnJERjCxHDRMUIKbFEY_R5zcSTVyVLT-A"}
                }
                """;

            var uri = new Uri("https://wibble.com/company/00002065/filing-history/id");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, json);
            var uriBuilder = new Mock<ICompanyFilingHistoryUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseCompanyFilingHistoryClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetFilingHistoryByTransactionAsync("00002065", "id");

            result.Data.ShouldNotBeNull();
            result.Data.Category.ShouldBe(new FilingCategory("mortgage"));
            result.Data.Subcategory.ShouldBe([new FilingSubcategory("create")]);
            result.Data.ActionDate.ShouldBe(new DateTime(2026, 05, 06));
            result.Data.Links?.DocumentMetaData.ShouldBe("https://document-api.company-information.service.gov.uk/document/yiC6UOsmY5UnJERjCxHDRMUIKbFEY_R5zcSTVyVLT-A");
        }
    }
}