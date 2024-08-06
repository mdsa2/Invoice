using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using Invoice.Infstracture.DataInvoice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Domain.Filter;
namespace Invoice.Infstracture.Repositry
{
    public class InvoiceItemRepositry(DataDbContext dbContext) : IInvoiceItemRepositry
    {
        public async Task AddInvoice(InvoiceItem invoice)
        {
            await dbContext.invoiceItems.AddAsync(invoice);
            await dbContext.SaveChangesAsync();
        }
 

        public async Task<InvoiceItem> GetInvoiceById(int invoiceId)
        {
            return await dbContext.invoiceItems.FirstOrDefaultAsync(i => i.Id == invoiceId);
        }

        public async Task UpdateInvoice(InvoiceItem invoice)
        {
            dbContext.invoiceItems.Update(invoice);
            await dbContext.SaveChangesAsync();
        }

        public void DeleteInvoice(InvoiceItem invoiceItem)
        {
            dbContext.invoiceItems.Remove(invoiceItem);
        }

        public async Task<List<InvoiceItem>> GetInvoiceItem(InvoiceItemFilter filter)
        {
            var query = dbContext.invoiceItems
                .Include(ii => ii.Product)
                .Include(ii => ii.ProductDiscounts)
                .Include(ii => ii.Invoices)
                .AsQueryable();

            if (filter.startDate.HasValue)
            {
                query = query.Where(ii => ii.Invoices != null && ii.Invoices.Updated >= filter.startDate.Value);
            }

            if (filter.endDate.HasValue)
            {
                query = query.Where(ii => ii.Invoices != null && ii.Invoices.Updated <= filter.endDate.Value);
            }

            return await query.ToListAsync();
        }


    }
}

