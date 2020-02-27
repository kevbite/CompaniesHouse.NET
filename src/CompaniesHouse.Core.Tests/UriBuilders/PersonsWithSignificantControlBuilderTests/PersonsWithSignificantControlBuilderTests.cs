using System;
using CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.OfficersUriBuilderTests
{
    public class PersonsWithSignificantControlBuilderTests
    {
        private PersonsWithSignificantControlBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
        private string _companyNumber;
        private int _pageSize;
        private int _startIndex;


        [OneTimeSetUp]
        public void GivenAUriBuilder()
        {
            _uriBuilder = new PersonsWithSignificantControlBuilder();
        }

        [SetUp]
        public void WhenBuildingUriWithCompanyNumber()
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
            var expected = $"/bla1/bla2/company/{_companyNumber}/persons-with-significant-control";
            Assert.That(uri.AbsolutePath, Is.EqualTo(expected));
        }

        [Test]
        public void ThenTheUriQueryStringIsCorrect()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var expected = $"?items_per_page={_pageSize}&start_index={_startIndex}";
            Assert.That(uri.Query, Is.EqualTo(expected));
        }
    }
}
