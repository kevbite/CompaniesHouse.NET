﻿using System;
using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public abstract partial class SearchUriBuilderTestsBase
    {
        private QuerySearchUriBuilder<SearchCompanyRequest> _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://testing123.co.uk/bla1/bla2/");

        private string Query { get; } = Guid.NewGuid().ToString();

        protected virtual int? ItemsPerPage { get; } = null;

        protected virtual int? StartIndex { get; } = null;

        private string _path;


        [OneTimeSetUp]
        public void GivenACompanySearchUriBuilder()
        {
            _path = "wat/wat/1";
            _uriBuilder = new QuerySearchUriBuilder<SearchCompanyRequest>(_path);
        }

        [SetUp]
        public void WhenBuildingUriWithCompanySearchRequest()
        {
            var request = new SearchCompanyRequest
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
