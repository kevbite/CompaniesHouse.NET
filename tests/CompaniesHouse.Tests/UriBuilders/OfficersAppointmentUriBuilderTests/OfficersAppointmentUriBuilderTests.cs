using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.OfficersAppointmentUriBuilderTests
{
    public class OfficersAppointmentUriBuilderTests
    {
        
        private OfficersAppointmentUriBuilder _uriBuilder;
        private Uri _actualUri;
        private readonly Uri _baseUri = new Uri("https://company.co.uk/bla1/bla2/");
        private string _companyNumber;
        private string _appointmentId;

        public OfficersAppointmentUriBuilderTests()
        {
            _uriBuilder = new OfficersAppointmentUriBuilder();
            _companyNumber = "123456789";
            _appointmentId = "appointmentId";
            _actualUri = _uriBuilder.Build(_companyNumber, _appointmentId);
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
            uri.AbsolutePath.ShouldBe($"/bla1/bla2/company/{_companyNumber}/appointments/{_appointmentId}");
        }
    }
}