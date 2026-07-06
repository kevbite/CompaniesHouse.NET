using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.OfficeAddressUriBuilderTests
{
    public class RegisteredOfficeUriBuilderTests
    {
        
        private RegisteredOfficeAddressUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("https://company.co.uk/bla1/bla2/");
        private string _companyNumber;
        
        public RegisteredOfficeUriBuilderTests()
        {
            _uriBuilder = new RegisteredOfficeAddressUriBuilder();
            _companyNumber = "123456789";
            _actualUri = _uriBuilder.Build(_companyNumber);
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
            uri.AbsolutePath.ShouldBe($"/bla1/bla2/company/{_companyNumber}/registered-office-address");
        }
    }
}