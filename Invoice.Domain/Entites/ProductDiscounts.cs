
namespace Invoice.Domain.Entites
{
    public  class ProductDiscounts:FullAuditedEntity<int>
    {
     
        public decimal? DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    public int ProductId { get; set; }
        public Products? Product { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }


    }
}
