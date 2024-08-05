
 
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.Wrapper;
using Invoice.Domain.Entites;
using Invoice.Domain.Filter;


namespace Invoice.Application.InvoiceItems.Services
{
    public interface IInvoiceItemService
    {
        Task<InvoiceItem> UpdateInvoiceItemAsync(int itemid, UpdateDtos itemDto);
        Task<bool> DeleteInvoiceItemAsync(int id);
        Task<InvoiceItem> AddInvoiceItemAsync(InvoiceItemDtos itemDto);
        Task<UpdateInvoiceItemResponseDto> GetInvoiceItemByIdAsync(int id);
        Task<IEnumerable<ProductDiscountSales>> GetProductSalesReportAsync(DateTime? startDate, DateTime? endDate);
      Task<List<MonthlyReportDiscount>> GetMonthlyReportDiscountAsync(DateTime? startDate, DateTime? endDate);
    }
}
