using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    public class StringArrayOrFieldEnumConverterTestsForMultipleValues : StringArrayOrFieldEnumConverterTestsBase
    {
        protected override string GetJson()
        {
            return @"[""compulsory"",""court-order""]";
        }

        [Fact]
        public void ThenMultipleItemsAreReturned()
        {
            Result.ShouldBe(new[] { new FilingSubcategory("compulsory"), new FilingSubcategory("court-order") });
        }
    }
}