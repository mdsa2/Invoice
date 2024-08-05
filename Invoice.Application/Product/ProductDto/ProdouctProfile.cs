using AutoMapper;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Product.ProductDto
{
    public class ProdouctProfile:Profile
    {
        public ProdouctProfile()
        {
            CreateMap<ProductDtos, Products>();
            CreateMap<Products, ProductDtos>();
            CreateMap<CreatedProductResponse, ProductDtos>();
            CreateMap<ProductDtos, CreatedProductResponse>();
            CreateMap<Products, CreatedProductResponse>();
            CreateMap<CreatedProductResponse, Products>();
         
            CreateMap<Products, ProductResponse>()
           
                
                ;
             
        }

    }
}
