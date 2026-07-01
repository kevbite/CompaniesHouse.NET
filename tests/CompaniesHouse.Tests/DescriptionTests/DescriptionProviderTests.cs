using CompaniesHouse.Description;
using Newtonsoft.Json.Linq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.DescriptionTests
{
    public class DescriptionProviderTests
    {
        [Fact]
        public void GivenFormatAndMatchingStringVariable()
        {
            var format = "some value: {variable}";
            var values = JObject.Parse(@"{ ""variable"": ""Value"" }");
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: Value");
        }
        [Fact]
        public void GivenFormatAndMatchingStringVariables()
        {
            var format = "some value: {variable1}, other value: {variable2}";
            var values = JObject.Parse(@"{ ""variable1"": ""Value1"", ""variable2"": ""Value2"" }");
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: Value1, other value: Value2");
        }

        [Fact]
        public void GivenFormatAndNotMatchingStringVariable()
        {
            var format = "some value: {variable}";
            var values = JObject.Parse(@"{ ""otherVariable"": ""Value"" }");
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: {variable}");
        }

        [Fact]
        public void GivenFormatAndMatchingCompoundVariable()
        {
            var format = "some value: {parent.variable}";
            var values = JObject.Parse(@"{ ""parent"": { ""variable"": ""Value"" }}");
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: Value");
        }

        [Fact]
        public void GivenFormatAndNoVariable()
        {
            var format = "some value: {nullvariable}";
            var result = DescriptionProvider.GetDescription(format, null);

            result.ShouldBe(@"some value: {nullvariable}");
        }
    }
}
