using Newtonsoft.Json;

namespace ApiWrapper.Models
{
    public class Customer
    {
        [JsonProperty("value")]
        public CustomerValue Value { get; set; }
    }

    public class CustomerValue : ValueProperties
    {
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

        [JsonProperty("accountManager")]
        public Properties AccountManager { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("invoiceEmail")]
        public string InvoiceEmail { get; set; }

        [JsonProperty("bankAccounts")]
        public object[] BankAccounts { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }

        [JsonProperty("phoneNumberMobile")]
        public long PhoneNumberMobile { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isPrivateIndividual")]
        public bool IsPrivateIndividual { get; set; }

        [JsonProperty("postalAddress")]
        public Properties PostalAddress { get; set; }

        [JsonProperty("physicalAddress")]
        public Properties PhysicalAddress { get; set; }

        [JsonProperty("deliveryAddress")]
        public object DeliveryAddress { get; set; }

        [JsonProperty("category1")]
        public object Category1 { get; set; }

        [JsonProperty("category2")]
        public object Category2 { get; set; }

        [JsonProperty("category3")]
        public object Category3 { get; set; }
    }
}
