using CompaniesHouse.Response;
using System.Text.Json;

namespace CompaniesHouse.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    public abstract class StringArrayOrFieldEnumConverterTestsBase
    {
        protected FilingSubcategory[] Result;

        protected StringArrayOrFieldEnumConverterTestsBase()
        {
            Result = JsonSerializer.Deserialize<FilingSubcategory[]>(
                GetJson(),
                CompaniesHouseJsonSerializerOptions.Default)!;
        }

        protected abstract string GetJson();
    }
}