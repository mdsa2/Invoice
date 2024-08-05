using Invoice.Application.Product.ProductDto;
using Invoice.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.ProductDiscount.ProductDiscountDtos
{
    public class CreateProductDiscountRepsonse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal? DiscountValue { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedByDate { get; set; } = DateTime.Now;
     
      
    }
}
