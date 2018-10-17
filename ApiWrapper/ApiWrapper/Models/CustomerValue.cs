using Newtonsoft.Json;

namespace ApiWrapper.Models
{
    public class CustomerValue 
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organizationNumber")]
        public string OrganizationNumber { get; set; }

        [JsonProperty("supplierNumber")]
        public long SupplierNumber { get; set; }

        [JsonProperty("customerNumber")]
        public long CustomerNumber { get; set; }

        [JsonProperty("isSupplier")]
        public bool IsSupplier { get; set; }

        [JsonProperty("isCustomer")]
        public bool IsCustomer { get; set; }

        [JsonProperty("isInactive")]
        public bool IsInactive { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("invoiceEmail")]
        public string InvoiceEmail { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }

        [JsonProperty("phoneNumberMobile")]
        public long PhoneNumberMobile { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isPrivateIndividual")]
        public bool IsPrivateIndividual { get; set; }

        [JsonProperty("deliveryAddress")]
        public string DeliveryAddress { get; set; }

        [JsonProperty("category1")]
        public string Category1 { get; set; }

        [JsonProperty("category2")]
        public string Category2 { get; set; }

        [JsonProperty("category3")]
        public string Category3 { get; set; }
    }
}
