namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class InsolvencyCase
    {
        public string CaseNumber { get; set; } = null!;
        
        public InsolvencyCaseLinks Links { get; set; } = null!;
        
        public int? TransactionId { get; set; }
    }
}