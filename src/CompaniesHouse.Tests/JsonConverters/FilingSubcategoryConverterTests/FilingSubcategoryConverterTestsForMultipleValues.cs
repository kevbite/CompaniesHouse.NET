using CompaniesHouse.Response;
using NUnit.Framework;

namespace CompaniesHouse.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    [TestFixture]
    public class FilingSubcategoryConverterTestsForMultipleValues : FilingSubcategoryConverterTestsBase
    {
        protected override string GetJson()
        {
            return @"[""compulsory"",""court-order""]";
        }

        [Test]
        public void ThenMultipleItemsAreReturned()
        {
            Assert.That(Result, Is.EqualTo(new[] {FilingSubcategory.Compulsory, FilingSubcategory.CourtOrder}));
        }
    }
}