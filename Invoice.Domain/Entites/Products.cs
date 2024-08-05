

using System.ComponentModel.DataAnnotations;
 

namespace Invoice.Domain.Entites
{
    public class Products:FullAuditedEntity<int>
    {
       
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? PartNumber { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
        public ICollection<ProductDiscounts> ProductsDiscounts { get; set;}
    }
}
