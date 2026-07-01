using System;
using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    public class OfficersSchemaTests
    {
        [IntegrationFact]
        public async Task GetOfficersAsync_DeserializesConfirmedTescoFields()
        {
            var client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));

            var result = await client.GetOfficersAsync("00445790", pageSize: 100);

            result.Data.ShouldNotBeNull();
            result.Data.TotalResults.ShouldBeGreaterThan(0);
            result.Data.ItemsPerPage.ShouldBe(100);
            result.Data.Kind.ShouldBe("officer-list");
            result.Data.Links?.Self.ShouldBe("/company/00445790/officers");

            var melissaBethell = result.Data.Items.Single(x => x.PersonNumber == "248450070003");
            melissaBethell.OfficerRole.ShouldBe(OfficerRole.Director);
            melissaBethell.OfficerId.ShouldBe("aqrS_F-2zIvSaMNtl1opqDV4-w0");
            melissaBethell.IdentityVerificationDetails.ShouldNotBeNull();
            melissaBethell.IdentityVerificationDetails.AppointmentVerificationStartOn.ShouldBe(new DateTime(2026, 07, 01));
            melissaBethell.IdentityVerificationDetails.AppointmentVerificationEndOn.ShouldBe(new DateTime(9999, 12, 31));
        }

        [IntegrationFact]
        public async Task GetOfficersAsync_DeserializesCorporateIdentificationAndAppointedBefore()
        {
            var client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));

            var tescoResult = await client.GetOfficersAsync("00445790", pageSize: 100);
            var informaResult = await client.GetOfficersAsync("03610056", pageSize: 100);

            var pre1992Officer = tescoResult.Data.Items.Single(
                x => x.Links?.Self == "/company/00445790/appointments/MyVEHTFfF_vmr04twNlBb1DmQFY");
            pre1992Officer.AppointedBefore.ShouldBe(new DateTime(1991, 06, 07));
            pre1992Officer.IsPre1992Appointment.ShouldBe(true);

            var corporateSecretary = informaResult.Data.Items.Single(
                x => x.Links?.Self == "/company/03610056/appointments/4F3DS_j7LgOTlBEE2xIfmM7wGhs");
            corporateSecretary.OfficerRole.ShouldBe(OfficerRole.CorporateSecretary);
            corporateSecretary.Identification.ShouldNotBeNull();
            corporateSecretary.Identification.IdentificationType.ShouldBe(IdentificationType.UkLimitedCompany);
            corporateSecretary.Identification.RegistrationNumber.ShouldBe("3849195");
        }
    }
}
