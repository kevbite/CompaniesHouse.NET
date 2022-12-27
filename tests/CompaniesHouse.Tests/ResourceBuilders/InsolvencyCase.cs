namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class InsolvencyCase
    {
        public string CaseNumber { get; set; }
        
        public InsolvencyCaseLinks Links { get; set; }
        
        public int? TransactionId { get; set; }
    }
}