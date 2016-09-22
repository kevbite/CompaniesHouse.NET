using System;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public abstract partial class SearchUriBuilderTestsBase
    {
        private SearchUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://liberis.co.uk/bla1/bla2/");

        private string Query { get; } = Guid.NewGuid().ToString();

        protected virtual int? ItemsPerPage { get; } = null;

        protected virtual int? StartIndex { get; } = null;

        private string _path;


        [OneTimeSetUp]
        public void GivenACompanySearchUriBuilder()
        {
            _path = "wat/wat/1";
            _uriBuilder = new SearchUriBuilder(_path);
        }

        [SetUp]
        public void WhenBuildingUriWithCompanySearchRequest()
        {
            var request = new SearchRequest
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
            Assert.That(uri.AbsolutePath, Is.EqualTo($"/bla1/bla2/{_path}"));
        }

        public Thens Then => new Thens(this);
   }
}
