using Newtonsoft.Json;

namespace ApiWrapper.Models
{
    public class Invoice
    {
        [JsonProperty("fullResultSize")]
        public long FullResultSize { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("versionDigest")]
        public string VersionDigest { get; set; }

        [JsonProperty("values")]
        public InvoiceValue[] Values { get; set; }
    }
}
