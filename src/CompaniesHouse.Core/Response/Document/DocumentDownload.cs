using System.IO;

namespace CompaniesHouse.Core.Response.Document
{
    public class DocumentDownload
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
        public long? ContentLength { get; set; }
    }
}