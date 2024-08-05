﻿using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using Invoice.Infstracture.DataInvoice;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infstracture.Repositry
{
    public class ProductDiscountsRepositry(DataDbContext dbContext) : IProductDiscountRepositry
    {
        public async Task AddProductDiscounts(ProductDiscounts productDiscounts)
        {
            var productExists = await dbContext.Products.AnyAsync(p => p.Id == productDiscounts.ProductId);
            if (!productExists)
            {
                throw new Exception($"Product with Id {productDiscounts.ProductId} does not exist.");
            }

            await dbContext.ProductDiscounts.AddAsync(productDiscounts);
            await dbContext.SaveChangesAsync();
        }
      

        public async Task DeleteProductDiscounts(ProductDiscounts productDiscounts)
        {
            dbContext.ProductDiscounts.Remove(productDiscounts);
            await dbContext.SaveChangesAsync();
        }
 

        public async Task<List<ProductDiscounts>> GetProductsDiscounts()
        {
         return   await dbContext.ProductDiscounts.ToListAsync();
             
        }

        public async Task<ProductDiscounts> GetProductsDiscountsById(int ProductDId)
        {
            return await dbContext.ProductDiscounts
            .SingleOrDefaultAsync(x => x.Id == ProductDId);

        }

        public async Task UpdateProductDiscounts(ProductDiscounts productDiscounts)
        {
            dbContext.ProductDiscounts.Update(productDiscounts);
            await dbContext.SaveChangesAsync();
        }
  
    }
}
