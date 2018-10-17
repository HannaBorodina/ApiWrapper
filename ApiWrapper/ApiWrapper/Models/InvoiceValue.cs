using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWrapper.Models
{
    public class InvoiceValue 
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("invoiceNumber")]
        public long InvoiceNumber { get; set; }

        [JsonProperty("invoiceDate")]
        public DateTimeOffset InvoiceDate { get; set; }

        [JsonProperty("customer")]
        [NotMapped]
        public Customer Customer { get; set; }

        [JsonProperty("invoiceDueDate")]
        public DateTimeOffset InvoiceDueDate { get; set; }

        [JsonProperty("kid")]
        public string Kid { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [NotMapped]
        [JsonProperty("orders")]
        public Properties[] Orders { get; set; }

        [NotMapped]
        [JsonProperty("voucher")]
        public Properties Voucher { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTimeOffset DeliveryDate { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("amountCurrency")]
        public long AmountCurrency { get; set; }

        [JsonProperty("amountExcludingVat")]
        public long AmountExcludingVat { get; set; }

        [JsonProperty("amountExcludingVatCurrency")]
        public long AmountExcludingVatCurrency { get; set; }

        [JsonProperty("amountRoundoff")]
        public long AmountRoundoff { get; set; }

        [JsonProperty("amountRoundoffCurrency")]
        public long AmountRoundoffCurrency { get; set; }

        [JsonProperty("amountOutstanding")]
        public long AmountOutstanding { get; set; }

        [JsonProperty("amountOutstandingTotal")]
        public long AmountOutstandingTotal { get; set; }

        [JsonProperty("sumRemits")]
        public long SumRemits { get; set; }

        [JsonProperty("currency")]
        [NotMapped]
        public Properties Currency { get; set; }

        [JsonProperty("isCreditNote")]
        public bool IsCreditNote { get; set; }

        [JsonProperty("postings")]
        [NotMapped]
        public Properties[] Postings { get; set; }

        [JsonProperty("reminders")]
        [NotMapped]
        public object[] Reminders { get; set; }
    }
}
