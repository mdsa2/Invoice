using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using Microsoft.EntityFrameworkCore;
using Invoice.Infstracture.DataInvoice;
 
using Invoice.Domain.Filter;
using Invoice.Domain.Util;
namespace Invoice.Infstracture.Repositry
{
    public class ProductRepositry(DataDbContext dbContext) : IProductRepositry
    {
        public async Task<PaginatedList<Products>> GetAllProducts(ProductFilter filter)
        {
            var query = dbContext.Products.AsQueryable();

     
            return await PaginatedList<Products>.CreateAsync(query, filter.PageNumber, filter.PageSize);
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
