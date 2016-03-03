using System;
using LiberisLabs.CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanyFilingUriBuilderTests
{
    public class CompanyFilingUriBuilderTests
    {
        private CompanyFilingUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
        private string _companyNumber;


        [OneTimeSetUp]
        public void GivenACompanyProfileUriBuilder()
        {
            _uriBuilder = new CompanyFilingUriBuilder();
        }

        [SetUp]
        public void WhenBuildingUriWithCompanySearchRequest()
        {
            _companyNumber = "123456789";
            _actualUri = _uriBuilder.Build(_companyNumber);
        }

        [Test]
        public void ThenTheUriIsNotAbsolute()
        {
            Assert.That(_actualUri.IsAbsoluteUri, Is.False);
        }

        [Test]
        public void ThenTheUriPathIsCorrect()
        {
            var uri = new Uri(_baseUri, _actualUri);
            Assert.That(uri.AbsolutePath, Is.EqualTo("/bla1/bla2/company/" + _companyNumber + "/filing-history"));
        }
    }
}
