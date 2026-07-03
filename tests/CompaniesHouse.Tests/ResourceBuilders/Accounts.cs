using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Accounts
    {
        public DateTime NextDue { get; set; }

        public AccountingReferenceDate AccountingReferenceDate { get; set; } = null!;

        public LastAccounts LastAccounts { get; set; } = null!;

        public NextAccounts NextAccounts { get; set; } = null!;

        public DateTime NextMadeUpTo { get; set; }

        public bool Overdue { get; set; }
    }
}