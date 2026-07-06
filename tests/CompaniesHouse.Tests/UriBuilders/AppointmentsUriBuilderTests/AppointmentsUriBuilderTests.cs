using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.AppointmentsUriBuilderTests
{
    public class AppointmentsUriBuilderTests
    {
        [Fact]
        public void Build_EncodesOfficerIdAndPaging()
        {
            var uri = new AppointmentsUriBuilder().Build("abc/123", 10, 50);

            uri.ShouldBe(new Uri("officers/abc%2F123/appointments?items_per_page=50&start_index=10", UriKind.Relative));
        }
    }
}
