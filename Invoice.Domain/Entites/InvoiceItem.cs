
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entites
{
    public class InvoiceItem:FullAuditedEntity<int>
    {

   
     
        public decimal DiscountValue { get; set; }
      
        public int Quantity { get; set; }
  
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NetAmount { get; set; }
      
 

        public int InvoiceId { get; set; }
        public Invoices Invoices { get; set; }
        public int ProductId { get; set; }
        public Products? Product { get; set; }
    public int ProductDiscountsId { get; set; }
        public ProductDiscounts? ProductDiscounts { get; set; }
    }
}

