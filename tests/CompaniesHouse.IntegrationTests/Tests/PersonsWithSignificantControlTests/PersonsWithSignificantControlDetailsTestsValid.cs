using System;
using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.PersonsWithSignificantControlTests
{
    public class PersonsWithSignificantControlDetailsTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public PersonsWithSignificantControlDetailsTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [IntegrationFact]
        public async Task ThenIndividualPscDetailsCanBeRetrievedFromAListItem()
        {
            if (!TryGetSuccess(await _client.GetPersonsWithSignificantControlAsync("11790215"), out var list))
            {
                return;
            }

            var item = list.Items?.FirstOrDefault(x => x.Kind.Value.StartsWith("individual-", StringComparison.Ordinal));
            item.ShouldNotBeNull();

            var notificationId = ExtractTrailingSegment(item.Links?.Self);
            notificationId.ShouldNotBeNullOrWhiteSpace();

            if (!TryGetSuccess(await _client.GetIndividualPersonWithSignificantControlAsync("11790215", notificationId!), out var detail))
            {
                return;
            }

            detail.Kind.Value.ShouldStartWith("individual-");
            detail.Links?.Self.ShouldNotBeNullOrWhiteSpace();
        }

        [IntegrationFact]
        public async Task ThenCorporateEntityPscDetailsCanBeRetrievedFromAListItem()
        {
            if (!TryGetSuccess(await _client.GetPersonsWithSignificantControlAsync("00617641"), out var list))
            {
                return;
            }

            var item = list.Items?.FirstOrDefault(x => x.Kind.Value.StartsWith("corporate-entity-", StringComparison.Ordinal));
            item.ShouldNotBeNull();

            var notificationId = ExtractTrailingSegment(item.Links?.Self);
            notificationId.ShouldNotBeNullOrWhiteSpace();

            if (!TryGetSuccess(await _client.GetCorporateEntityPersonWithSignificantControlAsync("00617641", notificationId!), out var detail))
            {
                return;
            }

            detail.Kind.Value.ShouldStartWith("corporate-entity-");
            detail.Identification.ShouldNotBeNull();
        }

        [IntegrationFact]
        public async Task ThenPscStatementListAndDetailCanBeRetrieved()
        {
            if (!TryGetSuccess(await _client.GetPersonsWithSignificantControlStatementsAsync("05124262"), out var list))
            {
                return;
            }

            list.Items.ShouldNotBeEmpty();

            var statement = list.Items[0];
            var statementId = ExtractTrailingSegment(statement.Links.Self);
            statementId.ShouldNotBeNullOrWhiteSpace();

            if (!TryGetSuccess(await _client.GetPersonsWithSignificantControlStatementAsync("05124262", statementId!), out var detail))
            {
                return;
            }

            detail.Statement.ShouldNotBeNullOrWhiteSpace();
            detail.Kind.ShouldContain("statement");
        }

        [IntegrationFact]
        public async Task ThenLegalPersonAndSuperSecureDetailsCanBeRetrievedWhenPresent()
        {
            var companies = new[] { "03977902", "11790215", "00617641", "05124262" };
            foreach (var company in companies)
            {
                var list = await _client.GetPersonsWithSignificantControlAsync(company);
                if (list is not CompaniesHouseResponse<PersonsWithSignificantControl>.Success success)
                {
                    if (list is CompaniesHouseResponse<PersonsWithSignificantControl>.RateLimited)
                    {
                        return;
                    }

                    continue;
                }

                var legal = success.Data.Items?.FirstOrDefault(x => x.Kind.Value.StartsWith("legal-person-", StringComparison.Ordinal));
                if (legal is not null)
                {
                    var legalId = ExtractTrailingSegment(legal.Links?.Self);
                    legalId.ShouldNotBeNullOrWhiteSpace();

                    if (legal.Kind.Value.Contains("beneficial-owner", StringComparison.Ordinal))
                    {
                        if (!TryGetSuccess(await _client.GetLegalPersonBeneficialOwnerAsync(company, legalId!), out var legalBo))
                        {
                            return;
                        }

                        legalBo.Kind.Value.ShouldStartWith("legal-person-");
                    }
                    else
                    {
                        if (!TryGetSuccess(await _client.GetLegalPersonPersonWithSignificantControlAsync(company, legalId!), out var legalDetail))
                        {
                            return;
                        }

                        legalDetail.Kind.Value.ShouldStartWith("legal-person-");
                    }
                }

                var superSecure = success.Data.Items?.FirstOrDefault(x => x.Kind.Value.StartsWith("super-secure-", StringComparison.Ordinal));
                if (superSecure is not null)
                {
                    var superSecureId = ExtractTrailingSegment(superSecure.Links?.Self);
                    superSecureId.ShouldNotBeNullOrWhiteSpace();

                    if (superSecure.Kind.Value.Contains("beneficial-owner", StringComparison.Ordinal))
                    {
                        if (!TryGetSuccess(await _client.GetSuperSecureBeneficialOwnerAsync(company, superSecureId!), out var bo))
                        {
                            return;
                        }

                        bo.Kind.ShouldStartWith("super-secure-");
                    }
                    else
                    {
                        if (!TryGetSuccess(await _client.GetSuperSecurePersonWithSignificantControlAsync(company, superSecureId!), out var psc))
                        {
                            return;
                        }

                        psc.Kind.ShouldStartWith("super-secure-");
                    }
                }

                if (legal is not null || superSecure is not null)
                {
                    return;
                }
            }

            return;
        }

        private static bool TryGetSuccess<T>(CompaniesHouseResponse<T> response, out T data)
        {
            switch (response)
            {
                case CompaniesHouseResponse<T>.Success success:
                    data = success.Data;
                    return true;
                case CompaniesHouseResponse<T>.RateLimited:
                    data = default!;
                    return false;
                default:
                    response.ShouldBeOfType<CompaniesHouseResponse<T>.Success>();
                    data = default!;
                    return false;
            }
        }

        private static string? ExtractTrailingSegment(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length == 0 ? null : parts[^1];
        }
    }
}
