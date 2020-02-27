using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response;
using Moq;
using NUnit.Framework;

namespace CompaniesHouse.Core.Tests.JsonConverters.FilingSubcategoryConverterTests
{
    [TestFixture]
    public class StringArrayOrFieldEnumConverterTestsForSingleValue : StringArrayOrFieldEnumConverterTestsBase
    {
        protected override string GetJson()
        {
            return @"""change""";
        }

        [Test]
        public void ThenSingleItemInAnArrayIsReturned()
        {
            Assert.That(Result, Is.EqualTo( new [] {FilingSubcategory.Change }));

        }
    }
}