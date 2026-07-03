using System;

namespace CompaniesHouse.UriBuilders
{
    public interface IPersonsWithSignificantControlDetailsUriBuilder
    {
        Uri BuildIndividual(string companyNumber, string notificationId);

        Uri BuildIndividualBeneficialOwner(string companyNumber, string notificationId);

        Uri BuildCorporateEntity(string companyNumber, string notificationId);

        Uri BuildCorporateEntityBeneficialOwner(string companyNumber, string notificationId);

        Uri BuildLegalPerson(string companyNumber, string notificationId);

        Uri BuildLegalPersonBeneficialOwner(string companyNumber, string notificationId);

        Uri BuildStatementsList(string companyNumber, int startIndex, int pageSize, bool? registerView);

        Uri BuildStatement(string companyNumber, string statementId);

        Uri BuildSuperSecure(string companyNumber, string superSecureId);

        Uri BuildSuperSecureBeneficialOwner(string companyNumber, string superSecureId);
    }
}
