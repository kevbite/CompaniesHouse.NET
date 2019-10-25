using System;
using System.Collections.Generic;

namespace CompaniesHouse.Tests.CompaniesHouseDocumentMetadataClientTests
{
    public class DocumentMetadataTestCase
    {
        public string CompanyNumber { get; set; }
        public string Barcode { get; set; }
        public DateTime SignificantDate { get; set; }
        public string SignificantDateType { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Etag { get; set; }
        public Dictionary<string, ResourceContentLength> Resources { get; set; }
        public Links Links { get; set; }
    }

    public class ResourceContentLength
    {
        public int ContentLength { get; set; }
    }

    public class Links
    {
        public string Self { get; set; }
        public string Document { get; set; }
    }
}