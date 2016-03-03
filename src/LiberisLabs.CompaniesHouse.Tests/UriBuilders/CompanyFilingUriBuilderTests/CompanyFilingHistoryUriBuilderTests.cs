using System;
using LiberisLabs.CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanyFilingUriBuilderTests
{
    public class CompanyFilingHistoryUriBuilderTests
    {
        private CompanyFilingHistoryUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
        private string _companyNumber;
        private int _pageSize;
        private int _startIndex;


        [OneTimeSetUp]
        public void GivenACompanyProfileUriBuilder()
        {
            _uriBuilder = new CompanyFilingHistoryUriBuilder();
        }

        [SetUp]
        public void WhenBuildingUriWithCompanySearchRequest()
        {
            _pageSize = 10;
            _startIndex = 5;
            _companyNumber = "123456789";
            _actualUri = _uriBuilder.Build(_companyNumber, _startIndex, _pageSize);
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
            var expected = string.Format("/bla1/bla2/company/{0}/filing-history", _companyNumber);
            Assert.That(uri.AbsolutePath, Is.EqualTo(expected));
        }

        [Test]
        public void ThenTheUriQueryStringIsCorrect()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var expected = string.Format("?items_per_page={0}&start_index={1}", _pageSize, _startIndex);
            Assert.That(uri.Query, Is.EqualTo(expected));
        }
    }
}
