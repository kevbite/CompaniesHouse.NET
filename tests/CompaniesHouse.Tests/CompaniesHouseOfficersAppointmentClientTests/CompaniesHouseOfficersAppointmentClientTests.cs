using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompaniesHouse.Tests.CompaniesHouseOfficersAppointmentClientTests
{
    [TestFixture]
    public class CompaniesHouseOfficersAppointmentClientTests
    {

        [TestCaseSource(nameof(TestCases))]
        public async Task GivenACompaniesHouseOffficerAppointmentClient_WhenGettingAnOfficerByAppointmentId(CompaniesHouseOfficerByAppointmentTestCase testCase)
        {
            var officersAppointment = OfficerBuilder.Build(testCase);
            var resource = OfficersResourceBuilder.CreateSingle(officersAppointment);
            
            var uri = new Uri("https://wibble.com/company/wobble/registered-office-address");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IOfficersAppointmentUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            
            var client = new CompaniesHouseOfficerByByAppointmentClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetOfficerByAppointmentIdAsync("abc", "1");
            
            result.Data.ShouldBeEquivalentTo(officersAppointment);
        }

        public static CompaniesHouseOfficerByAppointmentTestCase[] TestCases() =>
            EnumerationMappings.PossibleOfficerRoles.Keys
                .Select(x => new CompaniesHouseOfficerByAppointmentTestCase
                {
                    OfficerRole = x
                }).ToArray();
    }

}