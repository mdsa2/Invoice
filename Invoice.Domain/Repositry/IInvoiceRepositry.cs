
using Invoice.Domain.Entites;
namespace Invoice.Domain.Repositry
{
  public   interface  IInvoiceRepositry
    {
        Task<Invoices> GetInvoiceById(int invoiceId);
        Task AddInvoice(Invoices invoice);
        Task<List<Invoices>> GetInvoiceByDate(DateTime? startdate,DateTime? Endate);
 
        Task UpdateInvoice(Invoices invoice);
        Task DeleteInvoice(int invoiceId);
    }
}
