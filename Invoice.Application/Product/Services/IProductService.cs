


using Invoice.Application.Product.ProductDto;
using Invoice.Domain.Entites;
using Invoice.Domain.Filter;

namespace Invoice.Application.Product.Services
{
    public interface IProductService
    {
        Task<Products> UpdateProductAsync(int itemid,  ProductDtos productDto);
        Task<bool> DeleteProductAsync(int id);
        Task<Products> AddProductAsync(ProductDtos productDto);
        Task<Products> GetProductByIdAsync(int id);
        Task <List<CreatedProductResponse>> GetAllProductsAsync(ProductFilter filter);
    }
}
