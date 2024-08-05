using AutoMapper;
using Invoice.Application.Invoice.InvoiceDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Invoice.Domain.Entites;
using webs.Dtos;
namespace Invoice.Application.InvoiceItems.InvoiceItemDto
{
    public class InvoiceItemProfile:Profile
    {
        public InvoiceItemProfile()
        {
         

            CreateMap<InvoiceItem, UpdateDtos>().ReverseMap();
            CreateMap<InvoiceItem, UpdateInvoiceItemResponseDto>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemDtos>();
               


            ;

            CreateMap<InvoiceItem, MonthlyReportDiscount>()



                   .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Invoices.CreatedAt))
                       .ForMember(dest => dest.DiscountValue, opt => opt.MapFrom(src => src.ProductDiscounts.DiscountValue))
                            .ForMember(dest => dest.CreatedProductDiscountResponseDto, opt => opt.MapFrom(src => src.ProductDiscounts))
                         .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.Invoices.InvoiceNumber))
                   .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                     .ForMember(dest => dest.PartNumber, opt => opt.MapFrom(src => src.Product.PartNumber))
                        .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Product.Code))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                     .ForMember(dest => dest.NetAmount, opt => opt.MapFrom(src => src.Quantity * src.Price - (src.Quantity * src.ProductDiscounts.DiscountValue)))

                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.Price - (src.Quantity * src.ProductDiscounts.DiscountValue)));


            CreateMap<InvoiceItem, ProductDiscountSales>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                     .ForMember(dest => dest.PartNumber, opt => opt.MapFrom(src => src.Product.PartNumber))
                        .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Product.Code))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        }
    }
}
