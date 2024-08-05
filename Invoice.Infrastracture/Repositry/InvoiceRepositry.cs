
using Invoice.Infstracture.DataInvoice;
using Invoice.Domain.Repositry;
using Invoice.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infstracture.Repositry
{
    public class InvoiceRepositry : IInvoiceRepositry
    {
        private readonly DataDbContext _dbContext;

        public InvoiceRepositry(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddInvoice(Invoices invoice)
        {
            await _dbContext.invoices.AddAsync(invoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteInvoice(int invoiceId)
        {
            var invoiceitems = await _dbContext.invoices.FindAsync(invoiceId);
            _dbContext.invoices.Remove(invoiceitems);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Invoices>> GetInvoiceByDate(DateTime? startdate, DateTime? Endate)
        {

            return await _dbContext.invoices.ToListAsync();
        }

      

        public async Task<Invoices> GetInvoiceById(int invoiceId)
        {
            return await _dbContext.invoices.FirstOrDefaultAsync(i => i.Id == invoiceId);
        }

        public async Task UpdateInvoice(Invoices invoice)
        {
            _dbContext.invoices.Update(invoice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
