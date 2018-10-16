using Newtonsoft.Json;

namespace ApiWrapper.Models
{
    public class Properties
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
