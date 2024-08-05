using Invoice.Application.InvoiceItems.InvoiceItemDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Invoice.Application.Invoice.InvoiceDto
{
    public class updateInvoiceDto
    {
        public string CustomerName { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.UtcNow;
     
    }
}
