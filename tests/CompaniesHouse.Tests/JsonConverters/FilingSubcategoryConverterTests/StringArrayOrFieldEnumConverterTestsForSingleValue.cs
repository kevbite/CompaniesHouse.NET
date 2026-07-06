using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    public class StringArrayOrFieldEnumConverterTestsForSingleValue : StringArrayOrFieldEnumConverterTestsBase
    {
        protected override string GetJson()
        {
            return @"""change""";
        }

        [Fact]
        public void ThenSingleItemInAnArrayIsReturned()
        {
            Result.ShouldBe(new[] { new FilingSubcategory("change") });

        }
    }
}