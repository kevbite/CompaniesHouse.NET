using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders;
using LiberisLabs.CompaniesHouse.UriBuilders;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests
{
    [TestFixture]
    public class CompanyHouseSearchCompanyClientTests
    {
        private CompaniesHouseSearchCompanyClient _client;

        private CompaniesHouseClientResponse<CompanySearch> _result;
        private ResourceDetails _resourceDetails;
        private List<CompanyDetails> _expectedCompanies;


        [TestFixtureSetUp]
        public void GivenACompanyHouseSearchCompanyClient_WhenSearchingForACompany()
        {
            var fixture = new Fixture();
            _resourceDetails = fixture.Create<ResourceDetails>();
            _expectedCompanies = new List<CompanyDetails>
            {
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "active").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "dissolved").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "liquidation").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "receivership").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "administration").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "voluntary-arrangement").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "converted-closed").With(x => x.CompanyType, "private-unlimited").Create(),
                fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "insolvency-proceedings").With(x => x.CompanyType, "private-unlimited").Create(),
            };

            var uri = new Uri("https://wibble.com/search/companies");

            _companyWithUnknownDateOfCessation = fixture.Build<CompanyDetails>().With(x => x.CompanyStatus, "insolvency-proceedings").With(x => x.CompanyType, "private-unlimited").Create();
            var resource = new CompanySearchResourceBuilder()
                .AddCompanies(_expectedCompanies)
                .AddCompanyWithUnknownDateOfCessation(_companyWithUnknownDateOfCessation)
                .CreateResource(_resourceDetails);

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateHttpClient())
                .Returns(new HttpClient(handler));

            var uriBuilder = new Mock<ICompanySearchUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<CompanySearchRequest>()))
                .Returns(uri);

            _client = new CompaniesHouseSearchCompanyClient(httpClientFactory.Object, uriBuilder.Object);

            _result = _client.SearchCompanyAsync(new CompanySearchRequest()).Result;
        }

        [Test]
        public void ThenTheRootIsCorrect()
        {
            Assert.That(_result.Data.ETag, Is.EqualTo(_resourceDetails.ETag));
            Assert.That(_result.Data.ItemsPerPage, Is.EqualTo(_resourceDetails.ItemsPerPage));
            Assert.That(_result.Data.Kind, Is.EqualTo(_resourceDetails.Kind));
            Assert.That(_result.Data.PageNumber, Is.EqualTo(_resourceDetails.PageNumber));
            Assert.That(_result.Data.StartIndex, Is.EqualTo(_resourceDetails.StartIndex));
            Assert.That(_result.Data.TotalResults, Is.EqualTo(_resourceDetails.TotalResults));
        }

        [Test]
        public void ThenTheCompanyWithUnknownDateOfCessationIsReturned()
        {
            var actual = _result.Data.Companies.First(x => x.CompanyNumber == _companyWithUnknownDateOfCessation.CompanyNumber);

            Assert.That(actual.CompanyNumber, Is.EqualTo(_companyWithUnknownDateOfCessation.CompanyNumber));

            Assert.That(actual.Address.AddressLine1, Is.EqualTo(_companyWithUnknownDateOfCessation.AddressLine1));
            Assert.That(actual.Address.AddressLine2, Is.EqualTo(_companyWithUnknownDateOfCessation.AddressLine2));
            Assert.That(actual.Address.CareOf, Is.EqualTo(_companyWithUnknownDateOfCessation.CareOf));
            Assert.That(actual.Address.Country, Is.EqualTo(_companyWithUnknownDateOfCessation.Country));
            Assert.That(actual.Address.Locality, Is.EqualTo(_companyWithUnknownDateOfCessation.Locality));
            Assert.That(actual.Address.PoBox, Is.EqualTo(_companyWithUnknownDateOfCessation.PoBox));
            Assert.That(actual.Address.PostalCode, Is.EqualTo(_companyWithUnknownDateOfCessation.PostalCode));
            Assert.That(actual.Address.Region, Is.EqualTo(_companyWithUnknownDateOfCessation.Region));

            Assert.That(actual.CompanyStatus, Is.EqualTo(ExpectedCompanyStatus[_companyWithUnknownDateOfCessation.CompanyStatus]));
            Assert.That(actual.CompanyType, Is.EqualTo(ExpectedCompanyType[_companyWithUnknownDateOfCessation.CompanyType]));
            Assert.That(actual.DateOfCessation, Is.Null);
            Assert.That(actual.DateOfCreation, Is.EqualTo(_companyWithUnknownDateOfCessation.DateOfCreation.Date));
            Assert.That(actual.Description, Is.EqualTo(_companyWithUnknownDateOfCessation.Description));
            Assert.That(actual.Kind, Is.EqualTo(_companyWithUnknownDateOfCessation.Kind));
            Assert.That(actual.Links.Self, Is.EqualTo(_companyWithUnknownDateOfCessation.LinksSelf));
            Assert.That(actual.Matches.Title, Is.EqualTo(_companyWithUnknownDateOfCessation.MatchesTitle));
            Assert.That(actual.Snippet, Is.EqualTo(_companyWithUnknownDateOfCessation.Snippet));
            Assert.That(actual.Title, Is.EqualTo(_companyWithUnknownDateOfCessation.Title));
        }

        [Test]
        public void ThenTheNumberOfReturnedCompaniesIsCorrect()
        {
            Assert.That(_result.Data.Companies.Count(), Is.EqualTo(9));

        }

        [Test]
        public void ThenTheCompaniesAreCorrect()
        {
            foreach (var companyDetails in _expectedCompanies)
            {
                var actual = _result.Data.Companies.First(x => x.CompanyNumber == companyDetails.CompanyNumber);

                Assert.That(actual.CompanyNumber, Is.EqualTo(companyDetails.CompanyNumber));

                Assert.That(actual.Address.AddressLine1, Is.EqualTo(companyDetails.AddressLine1));
                Assert.That(actual.Address.AddressLine2, Is.EqualTo(companyDetails.AddressLine2));
                Assert.That(actual.Address.CareOf, Is.EqualTo(companyDetails.CareOf));
                Assert.That(actual.Address.Country, Is.EqualTo(companyDetails.Country));
                Assert.That(actual.Address.Locality, Is.EqualTo(companyDetails.Locality));
                Assert.That(actual.Address.PoBox, Is.EqualTo(companyDetails.PoBox));
                Assert.That(actual.Address.PostalCode, Is.EqualTo(companyDetails.PostalCode));
                Assert.That(actual.Address.Region, Is.EqualTo(companyDetails.Region));

                Assert.That(actual.CompanyStatus, Is.EqualTo(ExpectedCompanyStatus[companyDetails.CompanyStatus]));
                Assert.That(actual.CompanyType, Is.EqualTo(ExpectedCompanyType[companyDetails.CompanyType]));
                Assert.That(actual.DateOfCessation, Is.EqualTo(companyDetails.DateOfCessation.Date));
                Assert.That(actual.DateOfCreation, Is.EqualTo(companyDetails.DateOfCreation.Date));
                Assert.That(actual.Description, Is.EqualTo(companyDetails.Description));
                Assert.That(actual.Kind, Is.EqualTo(companyDetails.Kind));
                Assert.That(actual.Links.Self, Is.EqualTo(companyDetails.LinksSelf));
                Assert.That(actual.Matches.Title, Is.EqualTo(companyDetails.MatchesTitle));
                Assert.That(actual.Snippet, Is.EqualTo(companyDetails.Snippet));
                Assert.That(actual.Title, Is.EqualTo(companyDetails.Title));
            }
        }

        private static readonly IReadOnlyDictionary<string, CompanyStatus> ExpectedCompanyStatus = new Dictionary
            <string, CompanyStatus>()
        {
            {"active", CompanyStatus.Active},
            {"dissolved", CompanyStatus.Dissolved},
            {"liquidation", CompanyStatus.Liquidation},
            {"receivership", CompanyStatus.Receivership},
            {"administration", CompanyStatus.Administration},
            {"voluntary-arrangement", CompanyStatus.VoluntaryArrangement},
            {"converted-closed", CompanyStatus.ConvertedClosed},
            {"insolvency-proceedings", CompanyStatus.InsolvencyProceedings}
        };

        private static readonly IReadOnlyDictionary<string, CompanyType> ExpectedCompanyType = new Dictionary
    <string, CompanyType>()
        {
            {"private-unlimited", CompanyType.PrivateUnlimited}
        };

        private CompanyDetails _companyWithUnknownDateOfCessation;
    }
}
