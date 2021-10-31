using System;
using CompaniesHouse.UriBuilders;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.OfficersAppointmentUriBuilderTests
{
    [TestFixture]
    public class OfficersAppointmentUriBuilderTests
    {
        
        private OfficersAppointmentUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("https://company.co.uk/bla1/bla2/");
        private string _companyNumber;
        private string _appointmentId;

        [OneTimeSetUp]
        public void GivenACompanyProfileUriBuilder()
        {
            _uriBuilder = new OfficersAppointmentUriBuilder();
        }

        [SetUp]
        public void WhenBuildingUriWithCompanySearchRequest()
        {
            _companyNumber = "123456789";
            _appointmentId = "appointmentId";
            _actualUri = _uriBuilder.Build(_companyNumber, _appointmentId);
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
            Assert.That(uri.AbsolutePath, Is.EqualTo($"/bla1/bla2/company/{_companyNumber}/appointments/{_appointmentId}"));
        }
    }
}