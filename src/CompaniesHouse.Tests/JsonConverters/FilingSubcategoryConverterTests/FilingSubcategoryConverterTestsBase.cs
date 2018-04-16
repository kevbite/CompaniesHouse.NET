using System.IO;
using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CompaniesHouse.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    [TestFixture]
    public abstract class FilingSubcategoryConverterTestsBase
    {
        private FilingSubcategoryConverter _convertor;
        protected object Result;

        [OneTimeSetUp]
        public void GivenAFilingSubcategoryConverter()
        {
            _convertor = new FilingSubcategoryConverter();
        }

        [SetUp]
        public void WhenReadingJson()
        {
            var json = GetJson();
            var jsonTextReader = new JsonTextReader(new StringReader(json));
            jsonTextReader.Read();
            Result = _convertor.ReadJson(jsonTextReader, null, null, null);
        }

        protected abstract string GetJson();
    }
}