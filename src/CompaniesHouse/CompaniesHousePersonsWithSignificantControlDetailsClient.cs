using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    using CompaniesHouse.Extensions;

    public class CompaniesHousePersonsWithSignificantControlDetailsClient : ICompaniesHousePersonsWithSignificantControlDetailsClient
    {
        private readonly HttpClient _httpClient;
        private readonly IPersonsWithSignificantControlDetailsUriBuilder _uriBuilder;

        public CompaniesHousePersonsWithSignificantControlDetailsClient(HttpClient httpClient, IPersonsWithSignificantControlDetailsUriBuilder uriBuilder)
        {
            _httpClient = httpClient;
            _uriBuilder = uriBuilder;
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetIndividualPersonWithSignificantControlAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControl>(_uriBuilder.BuildIndividual(companyNumber, notificationId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetIndividualBeneficialOwnerAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControl>(_uriBuilder.BuildIndividualBeneficialOwner(companyNumber, notificationId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetCorporateEntityPersonWithSignificantControlAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControl>(_uriBuilder.BuildCorporateEntity(companyNumber, notificationId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetCorporateEntityBeneficialOwnerAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControl>(_uriBuilder.BuildCorporateEntityBeneficialOwner(companyNumber, notificationId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetLegalPersonPersonWithSignificantControlAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControl>(_uriBuilder.BuildLegalPerson(companyNumber, notificationId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetLegalPersonBeneficialOwnerAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControl>(_uriBuilder.BuildLegalPersonBeneficialOwner(companyNumber, notificationId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonsWithSignificantControlStatements>> GetPersonsWithSignificantControlStatementsAsync(string companyNumber, int startIndex = 0, int pageSize = 25, bool? registerView = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonsWithSignificantControlStatements>(_uriBuilder.BuildStatementsList(companyNumber, startIndex, pageSize, registerView), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<PersonWithSignificantControlStatement>> GetPersonsWithSignificantControlStatementAsync(string companyNumber, string statementId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PersonWithSignificantControlStatement>(_uriBuilder.BuildStatement(companyNumber, statementId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<SuperSecurePersonWithSignificantControl>> GetSuperSecurePersonWithSignificantControlAsync(string companyNumber, string superSecureId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SuperSecurePersonWithSignificantControl>(_uriBuilder.BuildSuperSecure(companyNumber, superSecureId), cancellationToken).ConfigureAwait(false);
        }

        public async Task<CompaniesHouseResponse<SuperSecurePersonWithSignificantControl>> GetSuperSecureBeneficialOwnerAsync(string companyNumber, string superSecureId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SuperSecurePersonWithSignificantControl>(_uriBuilder.BuildSuperSecureBeneficialOwner(companyNumber, superSecureId), cancellationToken).ConfigureAwait(false);
        }

        private async Task<CompaniesHouseResponse<T>> GetAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.ToCompaniesHouseResponseAsync<T>(cancellationToken).ConfigureAwait(false);
        }
    }
}
