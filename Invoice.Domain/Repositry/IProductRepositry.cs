using Invoice.Domain.Entites;
using Invoice.Domain.Filter;
 
namespace Invoice.Domain.Repositry
{
    public interface IProductRepositry
    {
        Task<Products> GetProductById(int id);
        Task AddProduct(Products product);
        Task<List<InvoiceItem>> GetInvoiceItemsAsync(DateTime? startDate ,DateTime? endDate);


        Task UpdateProduct(Products product);
        Task DeleteProduct(Products products);
    }
}
