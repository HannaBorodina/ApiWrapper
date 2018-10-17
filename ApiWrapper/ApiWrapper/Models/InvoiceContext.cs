using Microsoft.EntityFrameworkCore;

namespace ApiWrapper.Models
{
    public class InvoiceContext : DbContext
    {
        public DbSet<InvoiceValue> Invoices { get; set; }

        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
