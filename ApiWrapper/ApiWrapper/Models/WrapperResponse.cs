using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiWrapper.Models
{
    public class WrapperResponse
    {
        [JsonProperty("Success")]
        public string Success { get; set; }

        [JsonProperty("Value")]
        public List<InvoiceWrapped> Value { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
