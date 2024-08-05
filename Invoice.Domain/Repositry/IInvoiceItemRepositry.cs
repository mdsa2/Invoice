using Invoice.Domain.Entites;
 
namespace Invoice.Domain.Repositry
{
    public interface IInvoiceItemRepositry
    {
        Task<InvoiceItem> GetInvoiceById(int invoiceId);
        Task AddInvoice(InvoiceItem invoice);
        Task<List<InvoiceItem>> GetInvoiceItem(DateTime? startdate, DateTime? Endate);
        Task UpdateInvoice(InvoiceItem invoice);
       
        void DeleteInvoice(InvoiceItem invoiceItem);
    }
}
