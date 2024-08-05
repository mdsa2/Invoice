using AutoMapper;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.Product.ProductDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.ProductDiscount.ProductDiscountServices
{
    public class ProductDiscountServices (IProductDiscountRepositry productDiscountRepositry, IMapper mapper): IProductDiscountsServices
    {
     public async Task<CreateProductDiscountRepsonse> AddProductAsync(  ProductDiscountDto productDiscountsDto)
        {

            var ProductDiscount = new ProductDiscounts
            {
                ProductId = productDiscountsDto.ProductId,
                DiscountValue = productDiscountsDto.Discount,
                
              

            };
            
            await productDiscountRepositry.AddProductDiscounts(ProductDiscount);
              
            var product = mapper.Map<CreateProductDiscountRepsonse>(ProductDiscount);
            return product;
        }
        

 
        public async Task<bool> DeleteProductDiscountAsync(int id)
        {
            var productid = await productDiscountRepositry.GetProductsDiscountsById(id);
            if (productid == null)
            {
                return false;
            }
          await  productDiscountRepositry.DeleteProductDiscounts(productid);
            return true;
        }

        public async Task<List<CreateProductDiscountRepsonse>> GetAllProductsAsync()
        {
            var productDiscounts = await productDiscountRepositry.GetProductsDiscounts();
            var productDiscountDtos = mapper.Map<List<CreateProductDiscountRepsonse>>(productDiscounts);
            return productDiscountDtos;
        }


        public async Task<ProductDiscounts> GetProductByIdAsync(int id)
        {
            return await productDiscountRepositry.GetProductsDiscountsById(id);
        }

        public async Task<UpdateProductDiscountRepsonse> UpdateProductDiscountAsync(int itemid, UpdateProductDiscountRepsonse productDiscountDto)
        {
            var existingProduct = await productDiscountRepositry.GetProductsDiscountsById(itemid);
             
                existingProduct.ProductId = productDiscountDto.ProductId;
            existingProduct.DiscountValue = productDiscountDto.Discount;
          
           
 

            await productDiscountRepositry.UpdateProductDiscounts(existingProduct);
            var product = mapper.Map<UpdateProductDiscountRepsonse>(productDiscountDto);
            product.id = itemid;
            return product;
        } 
    }
}
 