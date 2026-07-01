using System.IO;
using CompaniesHouse.JsonConverters;
using CompaniesHouse.Response;
using Newtonsoft.Json;

namespace CompaniesHouse.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    public abstract class StringArrayOrFieldEnumConverterTestsBase
    {
        private StringArrayOrFieldEnumConverter _convertor;
        protected object Result;

        protected StringArrayOrFieldEnumConverterTestsBase()
        {
            _convertor = new StringArrayOrFieldEnumConverter();
            var json = GetJson();
            var jsonTextReader = new JsonTextReader(new StringReader(json));
            jsonTextReader.Read();
            Result = _convertor.ReadJson(jsonTextReader, typeof(FilingSubcategory[]), null, null);
        }

        protected abstract string GetJson();
    }
}