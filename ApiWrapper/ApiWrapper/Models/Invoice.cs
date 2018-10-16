using Newtonsoft.Json;
using System;

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

    public class InvoiceValue : ValueProperties
    {
        [JsonProperty("invoiceNumber")]
        public long InvoiceNumber { get; set; }

        [JsonProperty("invoiceDate")]
        public DateTimeOffset InvoiceDate { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("invoiceDueDate")]
        public DateTimeOffset InvoiceDueDate { get; set; }

        [JsonProperty("kid")]
        public string Kid { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("orders")]
        public Properties[] Orders { get; set; }

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
        public Properties Currency { get; set; }

        [JsonProperty("isCreditNote")]
        public bool IsCreditNote { get; set; }

        [JsonProperty("postings")]
        public Properties[] Postings { get; set; }

        [JsonProperty("reminders")]
        public object[] Reminders { get; set; }
    }
}
