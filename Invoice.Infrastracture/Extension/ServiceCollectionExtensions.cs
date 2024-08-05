
using Audit.Core;
using Invoice.Application.Invoice.InvoiceDto;
using Invoice.Application.Invoice.Services;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.InvoiceItems.Services;
using Invoice.Application.Product.ProductDto;
using Invoice.Application.Product.Services;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Invoice.Application.ProductDiscount.ProductDiscountServices;
using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using Invoice.Infstracture.DataInvoice;
using Invoice.Infstracture.Repositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Invoice.Infstracture.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionstring = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionstring);
            services.AddDbContext<DataDbContext>(options => options.UseNpgsql(connectionstring));
         
            services.AddScoped<IInvoiceRepositry, InvoiceRepositry>();
            services.AddScoped<IInvoiceItemRepositry, InvoiceItemRepositry>();
            services.AddScoped<IInvoiceService, InvoiceServices>();
           services.AddScoped<IInvoiceItemService, InvoiceItemService>(); 
            services.AddScoped<IProductRepositry, ProductRepositry>();
          services.AddScoped<IProductService, ProductServic>(); 
            services.AddScoped<IProductDiscountRepositry, ProductDiscountsRepositry>();
       services.AddScoped<IProductDiscountsServices, ProductDiscountServices>(); 
            services.AddAutoMapper(typeof(InvoiceProfile) );
            services.AddAutoMapper(typeof(InvoiceItemProfile) );
            services.AddAutoMapper(typeof(ProductDiscountsProfile) );
            services.AddAutoMapper(typeof(ProdouctProfile) );

     
        }
    }
}
