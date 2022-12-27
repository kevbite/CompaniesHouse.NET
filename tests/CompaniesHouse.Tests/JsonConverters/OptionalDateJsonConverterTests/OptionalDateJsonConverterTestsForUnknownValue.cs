using CompaniesHouse.JsonConverters;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CompaniesHouse.Tests.JsonConverters.OptionalDateJsonConverterTests
{
    [TestFixture]
    public class OptionalDateJsonConverterTestsForUnknownValue
    {
        private OptionalDateJsonConverter _convertor;
        private object _result;

        [OneTimeSetUp]
        public void GivenADateOfCessationJsonConverter()
        {
            _convertor = new OptionalDateJsonConverter();
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
