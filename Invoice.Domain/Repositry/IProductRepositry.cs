using Invoice.Domain.Entites;
using Invoice.Domain.Filter;
using Invoice.Domain.Util;
 
namespace Invoice.Domain.Repositry
{
    public interface IProductRepositry
    {
        Task<Products> GetProductById(int id);
        Task AddProduct(Products product);
        Task<PaginatedList<Products>> GetAllProducts(ProductFilter filter);


        Task UpdateProduct(Products product);
        Task DeleteProduct(Products products);
    }
}
