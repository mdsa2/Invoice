using AutoMapper;
using Invoice.Domain.Entites;

namespace Invoice.Application.ProductDiscount.ProductDiscountDtos
{
    public class ProductDiscountsProfile:Profile
    {
        public ProductDiscountsProfile()
        {
            CreateMap<ProductDiscounts,ProductDiscountDto>();
            CreateMap<ProductDiscountDto, ProductDiscounts>();
            CreateMap<CreateProductDiscountRepsonse, ProductDiscounts>().ReverseMap();
         
        

     
            CreateMap<UpdateProductDiscountRepsonse, ProductDiscountDto>();

        }

    }
}
