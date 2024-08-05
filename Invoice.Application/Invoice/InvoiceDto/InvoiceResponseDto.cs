using Invoice.Application.Invoice.InvoiceDto;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Domain.Entites;

namespace webs.Dtos
{
    public class InvoiceResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreateAt { get; set; }
    
        public List<MonthlyReportDiscount> InvoiceItems { get; set; }
 
   
    }
}
