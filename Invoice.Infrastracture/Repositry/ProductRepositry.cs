using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using Microsoft.EntityFrameworkCore;
using Invoice.Infstracture.DataInvoice;
using Invoice.Application.Wrapper;
using Invoice.Domain.Filter;
namespace Invoice.Infstracture.Repositry
{
    public class ProductRepositry(DataDbContext dbContext) : IProductRepositry
    {
        public async Task<PaginatedList<InvoiceItem>> GetInvoiceItemsAsync(InvoiceItemFilter filter)
        {
            var query = dbContext.invoiceItems.AsQueryable();

            if (filter.startDate.HasValue)
            {
                query = query.Where(i => i.CreatedAt >= filter.startDate.Value);
            }

            if (filter.endDate.HasValue)
            {
                query = query.Where(i => i.CreatedAt <= filter.endDate.Value);
            }

            return await Task.FromResult(PaginatedList<InvoiceItem>.Create(query, filter.PageNumber, filter.PageSize));
        }


        public async Task AddProduct(Products product)
        {
             dbContext.Products.Add(product);
  

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(Products products)
        {
         
                dbContext.Products.Remove(products);
                await dbContext.SaveChangesAsync();
            
        }

      

        public async Task<Products> GetProductById(int id)
        {
            var ProductId = await dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            return ProductId;
        }
      
  

        public async Task UpdateProduct(Products product)
        {
           
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
