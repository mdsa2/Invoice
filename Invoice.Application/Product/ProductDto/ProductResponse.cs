using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Product.ProductDto
{
    public class ProductResponse
    {
      
           
            public DateTime CreatedAt { get; set; }     
              
            public int? Quantity { get; set; }              
            public decimal? TotalPrice { get; set; }      
          
               
      
    }
}
