using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWrapper.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; } 

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
