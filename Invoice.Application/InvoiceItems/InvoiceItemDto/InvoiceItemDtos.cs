namespace Invoice.Application.InvoiceItems.InvoiceItemDto
{
    public  class InvoiceItemDtos
    {
   
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductDiscountsId { get; set; }
  
        public int Quantity { get; set; }
        public decimal Price { get; set; }
      
      

   
    }
}
