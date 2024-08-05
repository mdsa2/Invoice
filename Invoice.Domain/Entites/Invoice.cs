
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.Entites
{
    public class Invoices:FullAuditedEntity<int>
    {
 

        public string? CustomerName { get; set; }
       
        public string? InvoiceNumber { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow.AddHours(3);
  
        public List<InvoiceItem> InvoiceItems { get; set; }= new List<InvoiceItem>();

    }
}
