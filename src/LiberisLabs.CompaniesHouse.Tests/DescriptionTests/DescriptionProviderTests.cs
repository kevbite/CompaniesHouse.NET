using FluentAssertions;
using LiberisLabs.CompaniesHouse.Description;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.DescriptionTests
{
    [TestFixture]
    public class DescriptionProviderTests
    {
        [Test]
        public void GivenFormatAndMatchingStringVariable()
        {
            var format = "some value: {variable}";
            var values = JObject.Parse(@"{ ""variable"": ""Value"" }");
            var result = DescriptionProvider.GetDescription(format, values);

            result.Should().Be(@"some value: Value");
        }
        [Test]
        public void GivenFormatAndMatchingStringVariables()
        {
            var format = "some value: {variable1}, other value: {variable2}";
            var values = JObject.Parse(@"{ ""variable1"": ""Value1"", ""variable2"": ""Value2"" }");
            var result = DescriptionProvider.GetDescription(format, values);

            result.Should().Be(@"some value: Value1, other value: Value2");
        }

        [Test]
        public void GivenFormatAndNotMatchingStringVariable()
        {
            var format = "some value: {variable}";
            var values = JObject.Parse(@"{ ""otherVariable"": ""Value"" }");
            var result = DescriptionProvider.GetDescription(format, values);

            result.Should().Be(@"some value: {variable}");
        }

        [Test]
        public void GivenFormatAndMatchingCompoundVariable()
        {
            var format = "some value: {parent.variable}";
            var values = JObject.Parse(@"{ ""parent"": { ""variable"": ""Value"" }}");
            var result = DescriptionProvider.GetDescription(format, values);

            result.Should().Be(@"some value: Value");
        }

        [Test]
        public void GivenFormatAndNoVariable()
        {
            var format = "some value: {nullvariable}";
            var result = DescriptionProvider.GetDescription(format, null);

            result.Should().Be(@"some value: {nullvariable}");
        }
    }
}
