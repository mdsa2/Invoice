using Invoice.Application.InvoiceItems.InvoiceItemDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Invoice.InvoiceDto
{
    public  class UpdateInvoiceResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreatedByDate { get; set; } = DateTime.Now;
        public List<MonthlyReportDiscount> InvoiceItems { get; set; }
    }
}
