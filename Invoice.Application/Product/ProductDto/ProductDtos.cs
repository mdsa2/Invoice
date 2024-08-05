using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Invoice.Domain.Entites;
using System.Text.Json.Serialization;

namespace Invoice.Application.Product.ProductDto
{
    public class ProductDtos
    {

        public string Name { get; set; }
   
        public string Code { get; set; }
    
        public string PartNumber { get; set; }
      
    }
}
