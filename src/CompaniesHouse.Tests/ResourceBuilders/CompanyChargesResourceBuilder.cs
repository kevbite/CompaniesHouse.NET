using System.Linq;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class CompanyChargesResourceBuilder
    {
        private readonly Charges _charges;

        public CompanyChargesResourceBuilder(Charges charges) => _charges = charges;

        public string Create()
        {
            return $@"{{
    ""etag"" : ""{_charges.Etag}"",
    ""items"" : [
        {string.Join(",", _charges.Items.Select(GetChargesJson))}
    ],
   ""part_satisfied_count"" : {_charges.PartSatisfiedCount},
    ""satisfied_count"" : {_charges.SatisfiedCount},
    ""total_count"" : {_charges.TotalCount},
    ""unfiletered_count"" : {_charges.UnfileteredCount}
 }}";
        }

        private static string GetChargesJson(Charge charge) => $@"{{
    ""acquired_on"" : ""{charge.AcquiredOn?.ToString("yyyy-MM-dd")}"",
    ""assets_ceased_released"" : ""{charge.AssetsCeasedReleased}"",
    ""charge_code"" : ""{charge.ChargeCode}"",
    ""charge_number"" : {charge.ChargeNumber},
    ""classification"" : {{
        ""description"" : ""{charge.Classification.Description}"",
        ""type"" : ""{charge.Classification.Type}""
    }},
    ""covering_instrument_date"" : ""{charge.CoveringInstrumentDate?.ToString("yyyy-MM-dd")}"",
    ""created_on"" : ""{charge.CreatedOn?.ToString("yyyy-MM-dd")}"",
    ""delivered_on"" : ""{charge.DeliveredOn?.ToString("yyyy-MM-dd")}"",
    ""etag"" : ""{charge.Etag}"",
    ""id"" : ""{charge.Id}"",
    ""insolvency_cases"" : [
        {string.Join(",", charge.InsolvencyCases.Select(GetInsolvencyCaseJson))}
    ],
    ""links"" : {{
        ""self"" : ""{charge.Links?.Self}""
    }},
    ""more_than_four_persons_entitled"" : ""{charge.MoreThanFourPersonsEntitled}"",
    ""particulars"" : {{
        ""chargor_acting_as_bare_trustee"" : ""{charge.Particular?.ChargorActingAsBareTrustee}"",
        ""contains_fixed_charge"" : ""{charge.Particular?.ContainsFixedCharge}"",
        ""contains_floating_charge"" : ""{charge.Particular?.ContainsFloatingCharge}"",
        ""contains_negative_pledge"" : ""{charge.Particular?.ContainsNegativePledge}"",
        ""description"" : ""{charge.Particular?.Description}"",
        ""floating_charge_covers_all"" : ""{charge.Particular?.FloatingChargeCoversAll}"",
        ""type"" : ""{charge.Particular?.Type}""
    }},
    ""persons_entitled"" : [
        {string.Join(",", charge.PersonsEntitled.Select(GetPersonEntitledJson))}
    ],
    ""resolved_on"" : ""{charge.ResolvedOn?.ToString("yyyy-MM-dd")}"",
    ""satisfied_on"" : ""{charge.SatisfiedOn?.ToString("yyyy-MM-dd")}"",
    ""scottish_alterations"" : {{
        ""has_alterations_to_order"" : ""{charge.ScottishAlterations?.HasAlterationsToOrder}"",
        ""has_alterations_to_prohibitions"" : ""{charge.ScottishAlterations?.HasAlterationsToProhibitions}"",
        ""has_restricting_provisions"" : ""{charge.ScottishAlterations?.HasRestrictingProvisions}""
    }},
    ""secured_details"" : {{
        ""description"" : ""{charge.SecuredDetail?.Description}"",
        ""type"" : ""{charge.SecuredDetail?.Type}""
    }},
    ""status"" : ""{charge.Status}"",
    ""transactions"" : [
        {string.Join(",", charge.Transactions.Select(GetTransactionJson))}
    ]
}}";

        private static string GetInsolvencyCaseJson(InsolvencyCase insolvencyCase) =>
            $@"{{
    ""case_number"" : ""{insolvencyCase.CaseNumber}"",
    ""links"" : {{
        ""case"" : ""{insolvencyCase.Links?.Case}""
    }},
    ""transaction_id"" : {insolvencyCase.TransactionId}
}}";

        private static string GetPersonEntitledJson(PersonEntitled personEntitled) =>
            $@"{{
    ""name"" : ""{personEntitled.Name}""
}}";

        private static string GetTransactionJson(Transaction transaction) =>
            $@"{{
    ""delivered_on"" : ""{transaction.DeliveredOn?.ToString("yyyy-MM-dd")}"",
    ""filing_type"" : ""{transaction.FilingType}"",
    ""insolvency_case_number"" : {transaction.InsolvencyCaseNumber},
    ""links"" : {{
        ""filing"" : ""{transaction.Links?.Filing}"",
        ""insolvency_case"" : ""{transaction.Links?.InsolvencyCase}""
    }},
    ""transaction_id"" : {transaction.TransactionId}
}}";
    }
}