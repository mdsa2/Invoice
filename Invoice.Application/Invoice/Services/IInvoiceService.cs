using Invoice.Application.Invoice.InvoiceDto;
 
using Invoice.Domain.Entites;
 
using webs.Dtos;

namespace Invoice.Application.Invoice.Services
{
    public interface IInvoiceService
    {
  
 
      /*  */


        Task<UpdateInvoiceResponseDto> UpdateInvoiceAsync(updateInvoiceDto updateInvoiceDto, int invoiceId);
        Task<object> GetMonthlyProfitReport(DateTime? startDate,DateTime? EndDate);
   
        Task DeleteInvoiceAsync(int invoiceId);
  
        Task<InvoiceResponseDto> AddInvoiceAsync(CreateInvoiceDto createInvoiceDto);
        Task<List<Invoices>> GetInvoiceByDate(DateTime? StartDate, DateTime? EndDate);
        Task<object> GetProductReport(DateTime startDate, DateTime endDate, List<int> productIds);
        Task<Invoices> GetInvoiceById(int invoiceId);
     
        decimal CalculateATotalAmount(Invoices invoices);
        decimal CalculateTheTotalAmountOfDiscount(Invoices invoices);
        decimal CalculateTheNetAmount(Invoices invoices);
    }
}
