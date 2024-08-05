using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.InvoiceItems.InvoiceItemDto
{
    public class ProductDiscountSales
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? PartNumber { get; set; }
    }
}
