using Invoice.Domain.Entites;
using Invoice.Domain.Filter;
using Invoice.Domain.Util;

namespace Invoice.Domain.Repositry
{
    public interface IProductDiscountRepositry
    {

        Task AddProductDiscounts(ProductDiscounts productDiscounts);

        Task<PaginatedList<ProductDiscounts>> GetProductsDiscounts(ProductDiscountFilter filter);
        Task<ProductDiscounts> GetProductsDiscountsById(int ProductDId);
        Task UpdateProductDiscounts(ProductDiscounts productDiscounts);
        Task DeleteProductDiscounts(ProductDiscounts productDiscounts);
       
    }
}
