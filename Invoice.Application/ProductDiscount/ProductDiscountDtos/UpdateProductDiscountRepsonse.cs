using Invoice.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.ProductDiscount.ProductDiscountDtos
{
    public class UpdateProductDiscountRepsonse
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public decimal Discount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdateByDate { get; set; } = DateTime.Now;

    }
}
