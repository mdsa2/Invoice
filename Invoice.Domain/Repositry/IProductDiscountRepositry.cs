using Invoice.Domain.Entites;

namespace Invoice.Domain.Repositry
{
    public interface IProductDiscountRepositry
    {

        Task AddProductDiscounts(ProductDiscounts productDiscounts);

        Task<List<ProductDiscounts>> GetProductsDiscounts();
        Task<ProductDiscounts> GetProductsDiscountsById(int ProductDId);
        Task UpdateProductDiscounts(ProductDiscounts productDiscounts);
        Task DeleteProductDiscounts(ProductDiscounts productDiscounts);
       
    }
}
