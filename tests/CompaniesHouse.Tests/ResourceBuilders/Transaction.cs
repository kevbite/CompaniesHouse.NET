using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Transaction
    {
        public DateTime? DeliveredOn { get; set; }

        public string FilingType { get; set; }

        public int? InsolvencyCaseNumber { get; set; }

        public TransactionLinks Links { get; set; }

        public int? TransactionId { get; set; }
    }
}