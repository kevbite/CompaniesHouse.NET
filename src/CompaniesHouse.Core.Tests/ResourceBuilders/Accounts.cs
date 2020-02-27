using System;

namespace CompaniesHouse.Core.Tests.ResourceBuilders
{
    public class Accounts
    {
        public DateTime NextDue { get; set; }

        public AccountingReferenceDate AccountingReferenceDate { get; set; }

        public LastAccounts LastAccounts { get; set; }

        public NextAccounts NextAccounts { get; set; }

        public DateTime NextMadeUpTo { get; set; }

        public bool Overdue { get; set; }
    }
}