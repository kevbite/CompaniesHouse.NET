using System;
using System.Collections.Generic;

namespace CompaniesHouse.Tests.CompaniesHouseDocumentMetadataClientTests
{
    public class DocumentMetadataTestCase
    {
        public string CompanyNumber { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public DateTime SignificantDate { get; set; }
        public string SignificantDateType { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Pages { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Etag { get; set; } = null!;
        public Dictionary<string, ResourceContentLength> Resources { get; set; } = null!;
        public Links Links { get; set; } = null!;
    }

    public class ResourceContentLength
    {
        public long ContentLength { get; set; }
    }

    public class Links
    {
        public string Self { get; set; } = null!;
        public string Document { get; set; } = null!;
    }
}