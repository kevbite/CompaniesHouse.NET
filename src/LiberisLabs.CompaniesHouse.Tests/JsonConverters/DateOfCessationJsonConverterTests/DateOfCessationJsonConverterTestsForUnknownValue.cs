using System;
using System.IO;
using LiberisLabs.CompaniesHouse.JsonConverters;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.JsonConverters.DateOfCessationJsonConverterTests
{
    [TestFixture]
    public class DateOfCessationJsonConverterTestsForUnknownValue
    {
        private DateOfCessationJsonConverter _convertor;
        private object _result;

        [TestFixtureSetUp]
        public void GivenADateOfCessationJsonConverter()
        {
            _convertor = new DateOfCessationJsonConverter();
        }

        [SetUp]
        public void WhenReadingJsonWhenValueIsUnknown()
        {
            var jsonReader = new Mock<JsonReader>();
            jsonReader.Setup(x => x.Value).Returns("Unknown");
            _result = _convertor.ReadJson(jsonReader.Object, null, null, null);
        }

        [Test]
        public void ThenTheResultIsNull()
        {
            Assert.That(_result, Is.Null);
        }
    }
}
