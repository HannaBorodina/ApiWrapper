using Newtonsoft.Json;

namespace ApiWrapper.Models
{
    public class ValueProperties : Properties
    {
        [JsonProperty("version")]
        public long Version { get; set; }
    }
}
