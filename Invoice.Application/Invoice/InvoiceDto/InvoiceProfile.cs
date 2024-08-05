using AutoMapper;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Domain.Entites;
using webs.Dtos;

namespace Invoice.Application.Invoice.InvoiceDto
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<CreateInvoiceDto, Invoices>();


            CreateMap<updateInvoiceDto, Invoices>();
          

            CreateMap<updateInvoiceDto, InvoiceResponseDto>();
            CreateMap<Invoices, InvoiceResponseDto>()
                .ForMember(dest => dest.InvoiceItems, opt => opt.MapFrom(src => src.InvoiceItems))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName));
                
                 

    

        }


    }
}
