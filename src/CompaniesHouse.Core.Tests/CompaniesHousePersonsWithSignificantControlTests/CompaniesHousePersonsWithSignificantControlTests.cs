using System;
using System.Net.Http;
using CompaniesHouse.Core.Tests.ResourceBuilders;
using CompaniesHouse.Core.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PersonsWithSignificantControl = CompaniesHouse.Response.PersonsWithSignificantControl.PersonsWithSignificantControl;

namespace CompaniesHouse.Core.Tests.CompaniesHousePersonsWithSignificantControlTests
{
    [TestFixture]
    public class CompaniesHousePersonsWithSignificantControlTests
    {
        private CompaniesHousePersonsWithSignificantControlClient _client;

        private CompaniesHouseClientResponse<PersonsWithSignificantControl> _result;
        private ResourceBuilders.PersonsWithSignificantControl _personsWithSignificantControl;

        [Test]
        public void GivenACompaniesHouseCompanyProfileClient_WhenGettingPersonsWithSignificantControl()
        {
            _personsWithSignificantControl = new PersonsWithSignificantControlBuilder().Build();
            var resource = new PersonsWithSignificantControlResourceBuilder(_personsWithSignificantControl).Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IPersonsWithSignificantControlBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(uri);

            _client = new CompaniesHousePersonsWithSignificantControlClient(new HttpClient(handler), uriBuilder.Object);

            _result = _client.GetPersonsWithSignificantControlAsync("abc", 0, 25).Result;

            _result.Data.ShouldBeEquivalentTo(_personsWithSignificantControl);
        }
    }
}
