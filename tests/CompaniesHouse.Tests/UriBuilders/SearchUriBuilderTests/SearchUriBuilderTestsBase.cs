using System;
using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public abstract partial class SearchUriBuilderTestsBase
    {
        private readonly SearchUriBuilder<SearchCompanyRequest> _uriBuilder;
        private readonly Uri _baseUri = new Uri("http://testing123.co.uk/bla1/bla2/");

        private string Query { get; } = Guid.NewGuid().ToString();

        protected virtual int? ItemsPerPage { get; } = null;

        protected virtual int? StartIndex { get; } = null;

        private readonly string _path;

        protected SearchUriBuilderTestsBase()
        {
            _path = "wat/wat/1";
            _uriBuilder = new SearchUriBuilder<SearchCompanyRequest>(_path);
        }

        private Uri ActualUri => _uriBuilder.Build(new SearchCompanyRequest
        {
            Query = Query,
            ItemsPerPage = ItemsPerPage,
            StartIndex = StartIndex
        });

        [Fact]
        public void ThenTheUriIsNotAbsolute()
        {
            ActualUri.IsAbsoluteUri.ShouldBeFalse();
        }

        [Fact]
        public void ThenTheUriPathIsCorrect()
        {
            var uri = new Uri(_baseUri, ActualUri);
            uri.AbsolutePath.ShouldBe($"/bla1/bla2/{_path}");
        }

        public Thens Then => new Thens(this);
   }
}
