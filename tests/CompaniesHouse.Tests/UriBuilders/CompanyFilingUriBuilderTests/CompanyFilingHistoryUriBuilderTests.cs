using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.CompanyFilingUriBuilderTests
{
    public class CompanyFilingHistoryUriBuilderTests
    {
        private CompanyFilingHistoryUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");
        private string _companyNumber;
        private int _pageSize;
        private int _startIndex;


        public CompanyFilingHistoryUriBuilderTests()
        {
            _uriBuilder = new CompanyFilingHistoryUriBuilder();
            _pageSize = 10;
            _startIndex = 5;
            _companyNumber = "123456789";
            _actualUri = _uriBuilder.Build(_companyNumber, _startIndex, _pageSize);
        }

        [Fact]
        public void ThenTheUriIsNotAbsolute()
        {
            _actualUri.IsAbsoluteUri.ShouldBeFalse();
        }

        [Fact]
        public void ThenTheUriPathIsCorrect()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var expected = $"/bla1/bla2/company/{_companyNumber}/filing-history";
            uri.AbsolutePath.ShouldBe(expected);
        }

        [Fact]
        public void ThenTheUriQueryStringIsCorrect()
        {
            var uri = new Uri(_baseUri, _actualUri);
            var expected = $"?items_per_page={_pageSize}&start_index={_startIndex}";
            uri.Query.ShouldBe(expected);
        }
    }
}
