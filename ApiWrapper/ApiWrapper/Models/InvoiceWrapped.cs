using Newtonsoft.Json;

namespace ApiWrapper.Models
{
    public class InvoiceWrapped : InvoiceValue
    {
        [JsonProperty("customer")]
        public new CustomerValue Customer { get; set; }
    }
}
