using CompaniesHouse.Description;
using System.Text.Json;
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
            var values = JsonDocument.Parse(@"{ ""variable"": ""Value"" }").RootElement;
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: Value");
        }
        [Fact]
        public void GivenFormatAndMatchingStringVariables()
        {
            var format = "some value: {variable1}, other value: {variable2}";
            var values = JsonDocument.Parse(@"{ ""variable1"": ""Value1"", ""variable2"": ""Value2"" }").RootElement;
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: Value1, other value: Value2");
        }

        [Fact]
        public void GivenFormatAndNotMatchingStringVariable()
        {
            var format = "some value: {variable}";
            var values = JsonDocument.Parse(@"{ ""otherVariable"": ""Value"" }").RootElement;
            var result = DescriptionProvider.GetDescription(format, values);

            result.ShouldBe(@"some value: {variable}");
        }

        [Fact]
        public void GivenFormatAndMatchingCompoundVariable()
        {
            var format = "some value: {parent.variable}";
            var values = JsonDocument.Parse(@"{ ""parent"": { ""variable"": ""Value"" }}").RootElement;
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
