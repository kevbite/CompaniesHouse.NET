using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Charge
    {
        public DateTime? AcquiredOn { get; set; }

        public string AssetsCeasedReleased { get; set; }

        public string ChargeCode { get; set; }

        public int? ChargeNumber { get; set; }

        public Classification Classification { get; set; }

        public DateTime? CoveringInstrumentDate { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeliveredOn { get; set; }

        public string Etag { get; set; }

        public string Id { get; set; }

        public InsolvencyCase[] InsolvencyCases { get; set; }

        public Links Links { get; set; }

        public bool? MoreThanFourPersonsEntitled { get; set; }

        public Particular Particular { get; set; }

        public PersonEntitled[] PersonsEntitled { get; set; }

        public DateTime? ResolvedOn { get; set; }

        public DateTime? SatisfiedOn { get; set; }

        public ScottishAlterations ScottishAlterations { get; set; }

        public SecuredDetail SecuredDetail { get; set; }

        public string Status { get; set; }

        public Transaction[] Transactions { get; set; }
    }
}