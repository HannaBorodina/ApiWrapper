using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWrapper.Models;
using Newtonsoft.Json;

namespace ApiWrapper.Services
{
    public class ResponseGenerator : IResponseGenerator
    {
        public const string Succes = "true";
        public const string Failed = "false";

        public async Task<WrapperResponse> GenerateResponse(string value = null, string excMessage = null, string created = null)
        {
            var response = new WrapperResponse();

            response = await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(excMessage))
                {
                    response.Error = excMessage;
                    response.Success = Failed;

                    return response;
                }
                else if (!string.IsNullOrEmpty(value))
                {
                    response.Success = Succes;
                    response.Value = GetResponseType(value);

                    return response;
                }
                else if (!string.IsNullOrEmpty(created))
                {
                    response.Success = Succes;
                    response.Error = created;

                    return response;
                }

                return response;
            });

            return response;
        }

        private List<InvoiceWrapped> GetResponseType(string value)
        {
            var invoiceData = JsonConvert.DeserializeObject<Invoice>(value);
            var invoices = invoiceData.Values;

            var listWrapped = invoices.Select(i => new InvoiceWrapped
            {
                Amount = i.Amount,
                AmountCurrency = i.AmountCurrency,
                AmountExcludingVat = i.AmountExcludingVat,
                AmountExcludingVatCurrency = i.AmountExcludingVatCurrency,
                AmountOutstanding = i.AmountOutstanding,
                AmountOutstandingTotal = i.AmountOutstandingTotal,
                AmountRoundoff = i.AmountRoundoff,
                AmountRoundoffCurrency = i.AmountRoundoffCurrency,
                Comment = i.Comment,
                Currency = i.Currency,
                DeliveryDate = i.DeliveryDate,
                Id = i.Id,
                InvoiceDate = i.InvoiceDate,
                InvoiceDueDate = i.InvoiceDueDate,
                InvoiceNumber = i.InvoiceNumber,
                IsCreditNote = i.IsCreditNote,
                Kid = i.Kid,
                Orders = i.Orders,
                Postings = i.Postings,
                Reminders = i.Reminders,
                SumRemits = i.SumRemits,
                Url = i.Url,
                Version = i.Version,
                Voucher = i.Voucher
            }).ToList();

            var random = new Random();

            // random data for CustomerGeneration
            foreach (var invoice in listWrapped)
            {
                var randomData = random.Next();
                invoice.Customer = new CustomerValue
                {
                    Id = randomData,
                    Version = randomData,
                    Name = $"name{randomData}",
                    Url = $"url{randomData}"
                };
            }

            return listWrapped;
        }
    }
}
