using System;
using System.Collections.Specialized;
using System.Web;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanySearchUriBuilderTests
{
    public abstract partial class CompanySearchUriBuilderTestsBase
    {
        private CompanySearchUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");

        private string Query { get; } = Guid.NewGuid().ToString();

        protected virtual int? ItemsPerPage { get; } = null;

        protected virtual int? StartIndex { get; } = null;

        [TestFixtureSetUp]
        public void GivenACompanySearchUriBuilder()
        {
            _uriBuilder = new CompanySearchUriBuilder();
        }

        [SetUp]
        public void WhenBuildingUriWithCompanySearchRequest()
        {
            var request = new CompanySearchRequest
            {
                Query = Query,
                ItemsPerPage = ItemsPerPage,
                StartIndex = StartIndex
            };

            _actualUri = _uriBuilder.Build(request);
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
            Assert.That(uri.AbsolutePath, Is.EqualTo("/bla1/bla2/search/companies"));
        }

        public Thens Then => new Thens(this);
   }
}
