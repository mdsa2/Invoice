using Invoice.Application.Product.ProductDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Invoice.Domain.Entites;
using Invoice.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.ProductDiscount.ProductDiscountServices
{
    public interface IProductDiscountsServices
    {
        Task<UpdateProductDiscountRepsonse> UpdateProductDiscountAsync(int itemid, UpdateProductDiscountRepsonse productDiscountsDto);
        Task<bool> DeleteProductDiscountAsync(int id);
        Task<CreateProductDiscountRepsonse> AddProductAsync( ProductDiscountDto productDiscountsDto);
        Task<ProductDiscounts> GetProductByIdAsync(int id);
        Task<List<CreateProductDiscountRepsonse>> GetAllProductsAsync(ProductDiscountFilter filter);
    }
}
