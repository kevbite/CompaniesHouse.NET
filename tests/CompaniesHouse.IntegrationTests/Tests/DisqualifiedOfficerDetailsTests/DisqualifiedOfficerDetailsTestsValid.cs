using System;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.DisqualifiedOfficerDetailsTests
{
    public class DisqualifiedOfficerDetailsTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public DisqualifiedOfficerDetailsTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [IntegrationFact]
        public async Task ThenNaturalDisqualificationDetailsAreReturnedForASearchResult()
        {
            var search = await _client.SearchDisqualifiedOfficerAsync(new SearchDisqualifiedOfficerRequest { Query = "kevin", ItemsPerPage = 20 });
            var officerId = ExtractOfficerId(search.Data.DisqualifiedOfficers ?? [], "/disqualified-officers/natural/");

            officerId.ShouldNotBeNull();
            var result = await _client.GetNaturalDisqualificationAsync(officerId!);

            result.Data.Kind.ShouldBe("natural-disqualification");
            result.Data.Surname.ShouldNotBeNullOrWhiteSpace();
            result.Data.Disqualifications.ShouldNotBeEmpty();
            result.Data.Disqualifications[0].Reason.Act.ShouldNotBeNullOrWhiteSpace();
        }

        [IntegrationFact]
        public async Task ThenCorporateDisqualificationDetailsAreReturnedForASearchResult()
        {
            var search = await _client.SearchDisqualifiedOfficerAsync(new SearchDisqualifiedOfficerRequest { Query = "limited", ItemsPerPage = 50 });
            var officerId = ExtractOfficerId(search.Data.DisqualifiedOfficers ?? [], "/disqualified-officers/corporate/");

            officerId.ShouldNotBeNull();
            var result = await _client.GetCorporateDisqualificationAsync(officerId!);

            result.Data.Kind.ShouldBe("corporate-disqualification");
            result.Data.Name.ShouldNotBeNullOrWhiteSpace();
            result.Data.Disqualifications.ShouldNotBeEmpty();
            result.Data.Disqualifications[0].Reason.DescriptionIdentifier.ShouldNotBeNullOrWhiteSpace();
        }

        private static string? ExtractOfficerId(Response.Search.DisqualifiedOfficersSearch.DisqualifiedOfficer[] officers, string expectedPrefix)
        {
            foreach (var officer in officers)
            {
                var self = officer.Links?.Self;
                if (string.IsNullOrWhiteSpace(self) || !self.StartsWith(expectedPrefix, StringComparison.Ordinal))
                {
                    continue;
                }

                return self.Substring(expectedPrefix.Length);
            }

            return null;
        }
    }
}
