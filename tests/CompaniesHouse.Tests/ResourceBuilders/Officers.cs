namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Officers
    {
        public int ActiveCount { get; set; }

        public Officer[] Items { get; set; }

        public int ResignedCount { get; set; }
        
        public int TotalResults { get; set; }
        
        public int StartIndex { get; set; }
    }
}