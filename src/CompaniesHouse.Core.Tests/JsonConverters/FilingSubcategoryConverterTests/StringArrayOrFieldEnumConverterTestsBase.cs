using System.IO;
using CompaniesHouse.Core.JsonConverters;
using CompaniesHouse.Core.Response;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CompaniesHouse.Core.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    [TestFixture]
    public abstract class StringArrayOrFieldEnumConverterTestsBase
    {
        private StringArrayOrFieldEnumConverter _convertor;
        protected object Result;

        [OneTimeSetUp]
        public void GivenAFilingSubcategoryConverter()
        {
            _convertor = new StringArrayOrFieldEnumConverter();
        }

        [SetUp]
        public void WhenReadingJson()
        {
            var json = GetJson();
            var jsonTextReader = new JsonTextReader(new StringReader(json));
            jsonTextReader.Read();
            Result = _convertor.ReadJson(jsonTextReader, typeof(FilingSubcategory[]), null, null);
        }

        protected abstract string GetJson();
    }
}