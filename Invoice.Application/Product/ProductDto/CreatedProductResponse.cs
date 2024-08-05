using Invoice.Application.InvoiceItems.InvoiceItemDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Product.ProductDto
{
    public class CreatedProductResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string PartNumber { get; set; }
     
        public DateTime CreatedByDate { get; set; }  = DateTime.UtcNow;
        public List<MonthlyReportDiscount> InvoiceItemss { get; set; }  

        public ProductDtos? productDtos { get; set; }
        
    }
}
