using AutoFixture;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Tests.ResourceBuilders.CompanySearchResource;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    public class CompaniesHouseSearchClientTestsForCompanySearch
    {
        private CompaniesHouseSearchClient _client;

        private CompaniesHouseClientResponse<CompanySearch> _result;
        private ResourceDetails _resourceDetails;
        private List<CompanyDetails> _expectedCompanies;


        public CompaniesHouseSearchClientTestsForCompanySearch()
        {
            var fixture = new Fixture();
            _resourceDetails = fixture.Create<ResourceDetails>();
            _expectedCompanies = new List<CompanyDetails>
            {
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "active")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "dissolved")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "liquidation")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "receivership")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "administration")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "voluntary-arrangement")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "converted-closed")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "insolvency-proceedings")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "open")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "closed")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "closed-on")
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, () => (string)null)
                    .With(x => x.CompanyType, "private-unlimited").With(x => x.Kind, "searchresults#company").Create(),
            };

            var uri = new Uri("https://wibble.com/search/companies");

            _companyWithUnknownDateOfCessation = fixture.Build<CompanyDetails>()
                .With(x => x.CompanyStatus, "insolvency-proceedings").With(x => x.CompanyType, "private-unlimited")
                .With(x => x.Kind, "searchresults#company").Create();
            var resource = new CompanySearchResourceBuilder()
                .AddCompanies(_expectedCompanies)
                .AddCompanyWithUnknownDateOfCessation(_companyWithUnknownDateOfCessation)
                .CreateResource(_resourceDetails);

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            _client = new CompaniesHouseSearchClient(
                new HttpClient(handler) { BaseAddress = new Uri("https://wibble.com/") }, new SearchUriBuilderFactory());

            _result = _client.SearchAsync<SearchCompanyRequest, CompanySearch>(new SearchCompanyRequest()).Result;
        }

        [Fact]
        public void ThenTheRootIsCorrect()
        {
            _result.Data.ETag.ShouldBe(_resourceDetails.ETag);
            _result.Data.ItemsPerPage.ShouldBe(_resourceDetails.ItemsPerPage);
            _result.Data.Kind.ShouldBe(_resourceDetails.Kind);
            _result.Data.PageNumber.ShouldBe(_resourceDetails.PageNumber);
            _result.Data.StartIndex.ShouldBe(_resourceDetails.StartIndex);
            _result.Data.TotalResults.ShouldBe(_resourceDetails.TotalResults);
        }

        [Fact]
        public void ThenTheCompanyWithUnknownDateOfCessationIsReturned()
        {
            var actual =
                _result.Data.Companies.First(x => x.CompanyNumber == _companyWithUnknownDateOfCessation.CompanyNumber);

            actual.CompanyNumber.ShouldBe(_companyWithUnknownDateOfCessation.CompanyNumber);

            actual.Address.AddressLine1.ShouldBe(_companyWithUnknownDateOfCessation.AddressLine1);
            actual.Address.AddressLine2.ShouldBe(_companyWithUnknownDateOfCessation.AddressLine2);
            actual.Address.CareOf.ShouldBe(_companyWithUnknownDateOfCessation.CareOf);
            actual.Address.Country.ShouldBe(_companyWithUnknownDateOfCessation.Country);
            actual.Address.Locality.ShouldBe(_companyWithUnknownDateOfCessation.Locality);
            actual.Address.PoBox.ShouldBe(_companyWithUnknownDateOfCessation.PoBox);
            actual.Address.PostalCode.ShouldBe(_companyWithUnknownDateOfCessation.PostalCode);
            actual.Address.Region.ShouldBe(_companyWithUnknownDateOfCessation.Region);

            actual.CompanyStatus.ShouldBe(ExpectedCompanyStatus[_companyWithUnknownDateOfCessation.CompanyStatus]);
            actual.CompanyType.ShouldBe(ExpectedCompanyType[_companyWithUnknownDateOfCessation.CompanyType]);
            actual.DateOfCessation.ShouldBeNull();
            actual.DateOfCreation.ShouldBe(_companyWithUnknownDateOfCessation.DateOfCreation.Date);
            actual.Description.ShouldBe(_companyWithUnknownDateOfCessation.Description);
            actual.Kind.ShouldBe(_companyWithUnknownDateOfCessation.Kind);
            actual.Links.Self.ShouldBe(_companyWithUnknownDateOfCessation.LinksSelf);
            actual.Matches.Title.ShouldBe(_companyWithUnknownDateOfCessation.MatchesTitle);
            actual.Snippet.ShouldBe(_companyWithUnknownDateOfCessation.Snippet);
            actual.Title.ShouldBe(_companyWithUnknownDateOfCessation.Title);
        }

        [Fact]
        public void ThenTheNumberOfReturnedCompaniesIsCorrect()
        {
            _result.Data.Companies.Length.ShouldBe(13);
        }

        [Fact]
        public void ThenTheCompaniesAreCorrect()
        {
            foreach (var companyDetails in _expectedCompanies)
            {
                var actual = _result.Data.Companies.First(x => x.CompanyNumber == companyDetails.CompanyNumber);

                actual.CompanyNumber.ShouldBe(companyDetails.CompanyNumber);

                actual.Address.AddressLine1.ShouldBe(companyDetails.AddressLine1);
                actual.Address.AddressLine2.ShouldBe(companyDetails.AddressLine2);
                actual.Address.CareOf.ShouldBe(companyDetails.CareOf);
                actual.Address.Country.ShouldBe(companyDetails.Country);
                actual.Address.Locality.ShouldBe(companyDetails.Locality);
                actual.Address.PoBox.ShouldBe(companyDetails.PoBox);
                actual.Address.PostalCode.ShouldBe(companyDetails.PostalCode);
                actual.Address.Region.ShouldBe(companyDetails.Region);

                actual.CompanyStatus.ShouldBe(ExpectedCompanyStatus[companyDetails.CompanyStatus ?? ""]);
                actual.CompanyType.ShouldBe(ExpectedCompanyType[companyDetails.CompanyType]);
                actual.DateOfCessation.ShouldBe(companyDetails.DateOfCessation.Date);
                actual.DateOfCreation.ShouldBe(companyDetails.DateOfCreation.Date);
                actual.Description.ShouldBe(companyDetails.Description);
                actual.Kind.ShouldBe(companyDetails.Kind);
                actual.Links.Self.ShouldBe(companyDetails.LinksSelf);
                actual.Matches.Title.ShouldBe(companyDetails.MatchesTitle);
                actual.Snippet.ShouldBe(companyDetails.Snippet);
                actual.Title.ShouldBe(companyDetails.Title);
            }
        }

        private static readonly IReadOnlyDictionary<string, CompanyStatus> ExpectedCompanyStatus = new Dictionary
            <string, CompanyStatus>()
            {
                { "", default },
                { "active", CompanyStatus.Active },
                { "dissolved", CompanyStatus.Dissolved },
                { "liquidation", CompanyStatus.Liquidation },
                { "receivership", CompanyStatus.Receivership },
                { "administration", CompanyStatus.Administration },
                { "voluntary-arrangement", CompanyStatus.VoluntaryArrangement },
                { "converted-closed", CompanyStatus.ConvertedClosed },
                { "insolvency-proceedings", CompanyStatus.InsolvencyProceedings },
                { "open", CompanyStatus.Open },
                { "closed", CompanyStatus.Closed },
                { "closed-on", CompanyStatus.ClosedOn },
                { "registered", CompanyStatus.Registered },
                { "removed", CompanyStatus.Removed },
            };

        private static readonly IReadOnlyDictionary<string, CompanyType> ExpectedCompanyType = new Dictionary
            <string, CompanyType>()
            {
                { "private-unlimited", CompanyType.PrivateUnlimited }
            };

        private CompanyDetails _companyWithUnknownDateOfCessation;
    }
}