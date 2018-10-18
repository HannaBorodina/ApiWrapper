using ApiWrapper.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public class DBService : IDBService
    {
        private InvoiceContext _context;

        public DBService(InvoiceContext context)
        {
            _context = context;
        }
        public async Task AddDataToDB<T>(string data)
        {
            if (typeof(T) == typeof(Invoice))
            {
                var invResponse = JsonConvert.DeserializeObject<Invoice>(data);
                var invoices = invResponse.Values;

                foreach (var invoice in invoices)
                {
                    if (_context.Invoices.FirstOrDefault(i => i.Id == invoice.Id) == null)
                        _context.Invoices.Add(invoice);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
