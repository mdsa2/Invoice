using Invoice.Application.Product.ProductDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using webs.Dtos;

namespace Invoice.Application.InvoiceItems.InvoiceItemDto
{
    public class MonthlyReportDiscount
    {
        public int Id { get; set; }

      
       
      
        public DateTime? CreatedAt { get; set; }
    

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NetAmount { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string PartNumber { get; set; }
        public decimal? DiscountValue { get; set; }
        public CreateProductDiscountRepsonse CreatedProductDiscountResponseDto { get; set; }

    }
}
