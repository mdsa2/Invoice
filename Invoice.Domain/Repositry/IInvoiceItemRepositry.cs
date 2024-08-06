using Invoice.Domain.Entites;
using Invoice.Domain.Filter;
 
namespace Invoice.Domain.Repositry
{
    public interface IInvoiceItemRepositry
    {
        Task<InvoiceItem> GetInvoiceById(int invoiceId);
        Task AddInvoice(InvoiceItem invoice);
        Task<List<InvoiceItem>> GetInvoiceItem(InvoiceItemFilter filter);
        Task UpdateInvoice(InvoiceItem invoice);
       
        void DeleteInvoice(InvoiceItem invoiceItem);
    }
}
