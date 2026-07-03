using System.Threading.Tasks;
using CompaniesHouse.Request;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class DissolvedCompaniesSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public DissolvedCompaniesSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [IntegrationTheory]
        [InlineData("CARILLION")]
        [InlineData("BLOCKBUSTER")]
        public async Task ThenCompaniesAreReturned(string query)
        {
            var result = await _client.SearchDissolvedCompaniesAsync(new SearchDissolvedCompaniesRequest
            {
                Query = query,
                SearchType = "best-match",
                Size = 25,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Items.ShouldNotBeEmpty();
        }

        [IntegrationFact]
        public async Task ThenPreviousNameSearchReturnsMatchedPreviousCompanyName()
        {
            var result = await SearchPreviousNamesAsync();

            // Retry once on 5xx server error
            if (result is CompaniesHouseResponse<Response.Search.DissolvedCompaniesSearch.DissolvedCompaniesSearch>.ServerError)
            {
                result = await SearchPreviousNamesAsync();
            }

            result.Data.Kind.ShouldBe("search#previous-name-dissolved");
            result.Data.TopHit.MatchedPreviousCompanyName.ShouldNotBeNull();
            result.Data.TopHit.MatchedPreviousCompanyName.Name.ShouldContain("RADIO RENTALS");
        }

        [IntegrationFact]
        public async Task ThenAlphabeticalSearchReturnsOrderedAlphaKeys()
        {
            var result = await _client.SearchDissolvedCompaniesAsync(new SearchDissolvedCompaniesRequest
            {
                Query = "tes",
                SearchType = "alphabetical",
                Size = 10,
            });

            result.Data.Kind.ShouldBe("search#alphabetical-dissolved");
            result.Data.Items.ShouldContain(x => !string.IsNullOrWhiteSpace(x.OrderedAlphaKeyWithId));
        }

        private Task<CompaniesHouseResponse<Response.Search.DissolvedCompaniesSearch.DissolvedCompaniesSearch>> SearchPreviousNamesAsync() =>
            _client.SearchDissolvedCompaniesAsync(new SearchDissolvedCompaniesRequest
            {
                Query = "radio rentals",
                SearchType = "previous-name-dissolved",
                Size = 10,
            });
    }
}
