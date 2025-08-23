using System;
using System.Collections.Generic;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    public abstract partial class AdvancedSearchCompanyUriBuilderTestsBase
    {
        private AdvancedSearchCompanyUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("http://testing123.co.uk/bla1/bla2/");
        
        protected virtual int? ItemsPerPage { get; } = null;
        protected virtual int? StartIndex { get; } = null;
        protected virtual string CompanyNameIncludes { get; } = null;
        protected virtual string CompanyNameExcludes { get; } = null;
        protected virtual IReadOnlyCollection<CompanyStatus> CompanyStatus { get; } = Array.Empty<CompanyStatus>();
        protected virtual IReadOnlyCollection<CompanySubType> CompanySubtype { get; } = Array.Empty<CompanySubType>();
        protected virtual IReadOnlyCollection<CompanyType> CompanyType { get; } = Array.Empty<CompanyType>();
        protected virtual DateTime? DissolvedFrom { get; } = null;
        protected virtual DateTime? DissolvedTo { get; } = null;
        protected virtual DateTime? IncorporatedFrom { get; } = null;
        protected virtual DateTime? IncorporatedTo { get; } = null;
        protected virtual string Location { get; } = null;
        protected virtual IReadOnlyCollection<string> SicCodes { get; } = Array.Empty<string>();

        private string _path;

        [OneTimeSetUp]
        public void GivenAnAdvancedSearchCompanyUriBuilder()
        {
            _path = "wat/wat/1";
            _uriBuilder = new AdvancedSearchCompanyUriBuilder(_path);
        }

        [SetUp]
        public void WhenBuildingUriWithAdvancedSearchCompanyRequest()
        {
            var request = new AdvancedSearchCompanyRequest
            {
                ItemsPerPage = ItemsPerPage,
                StartIndex = StartIndex,
                CompanyNameIncludes = CompanyNameIncludes,
                CompanyNameExcludes = CompanyNameExcludes,
                CompanyStatus = CompanyStatus,
                CompanySubtype = CompanySubtype,
                CompanyType = CompanyType,
                DissolvedFrom = DissolvedFrom,
                DissolvedTo = DissolvedTo,
                IncorporatedFrom = IncorporatedFrom,
                IncorporatedTo = IncorporatedTo,
                Location = Location,
                SicCodes = SicCodes
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
