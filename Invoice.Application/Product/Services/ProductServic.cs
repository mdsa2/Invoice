using AutoMapper;
using Invoice.Application.Product.ProductDto;
using Invoice.Domain.Repositry;
using Invoice.Domain.Entites;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Microsoft.EntityFrameworkCore;
namespace Invoice.Application.Product.Services
{
    public class ProductServic(IProductRepositry productRepositry , IMapper _mapper)  : IProductService 
    {
 
        public async Task<Products> AddProductAsync(ProductDtos productDto)
        {

            var productnew = new Products
            {
                Name = productDto.Name,
                Code = productDto.Code,
                PartNumber = productDto.PartNumber,
            };

         await  productRepositry.AddProduct(productnew);
         
            var product = _mapper.Map<Products>(productnew);
        
          return product;

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var productid = await productRepositry.GetProductById(id);
            if (productid == null)
            {
                return false;
            }
            productRepositry.DeleteProduct(productid);
            return true;
        }


    
            public async Task<List<CreatedProductResponse>> GetAllProductsAsync(DateTime? startDate,DateTime? endDate)
        {
            
            var products = await productRepositry.GetInvoiceItemsAsync(startDate,endDate);

            
            var productResponses = products.Select(products => _mapper.Map<CreatedProductResponse>(products)).ToList();

            return productResponses;
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await productRepositry.GetProductById(id);

        }

        public async Task<Products> UpdateProductAsync(int itemid, ProductDtos productDto)
        {
     
            var existingProduct = await productRepositry.GetProductById(itemid);

         if (existingProduct == null )
            {
                throw new Exception("the Id Not Found");
            }
            existingProduct.Name = productDto.Name;
            existingProduct.Code = productDto.Code;
            existingProduct.PartNumber = productDto.PartNumber;
            

            await productRepositry.UpdateProduct(existingProduct);
            var product = _mapper.Map<Products>(productDto);
          
            return product;
        }
 
    }
}
