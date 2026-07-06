using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Charge
    {
        public DateTime? AcquiredOn { get; set; }

        public string AssetsCeasedReleased { get; set; } = null!;

        public string ChargeCode { get; set; } = null!;

        public int? ChargeNumber { get; set; }

        public Classification Classification { get; set; } = null!;

        public DateTime? CoveringInstrumentDate { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeliveredOn { get; set; }

        public string Etag { get; set; } = null!;

        public string Id { get; set; } = null!;

        public InsolvencyCase[] InsolvencyCases { get; set; } = null!;

        public Links Links { get; set; } = null!;

        public bool? MoreThanFourPersonsEntitled { get; set; }

        public Particular Particular { get; set; } = null!;

        public PersonEntitled[] PersonsEntitled { get; set; } = null!;

        public DateTime? ResolvedOn { get; set; }

        public DateTime? SatisfiedOn { get; set; }

        public ScottishAlterations ScottishAlterations { get; set; } = null!;

        public SecuredDetail SecuredDetail { get; set; } = null!;

        public string Status { get; set; } = null!;

        public Transaction[] Transactions { get; set; } = null!;
    }
}