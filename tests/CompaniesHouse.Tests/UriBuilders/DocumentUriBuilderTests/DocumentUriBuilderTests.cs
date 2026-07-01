using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.DocumentUriBuilderTests
{
    public class DocumentUriBuilderTests
    {
        [Fact]
        public void MetadataBuilder_EncodesDocumentId()
        {
            var uri = new DocumentMetadataUriBuilder().Build("abc/123");

            uri.ShouldBe(new Uri("/document/abc%2F123", UriKind.Relative));
        }

        [Fact]
        public void ContentBuilder_EncodesDocumentId()
        {
            var uri = new DocumentContentUriBuilder().Build("abc/123");

            uri.ShouldBe(new Uri("/document/abc%2F123/content", UriKind.Relative));
        }
    }
}
