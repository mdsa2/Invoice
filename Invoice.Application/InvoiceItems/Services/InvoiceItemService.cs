using AutoMapper;
using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.Product.ProductDto;
using Invoice.Domain.Entites;
using Invoice.Domain.Filter;
using Invoice.Domain.Repositry;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace Invoice.Application.InvoiceItems.Services
{
    public class InvoiceItemService(IInvoiceItemRepositry invoiceItemRepositry, IMapper mapper) : IInvoiceItemService
    {

        
                public async Task<InvoiceItem> AddInvoiceItemAsync(InvoiceItemDtos itemDto)
                {



                    var invoiceItem = new InvoiceItem
                    {

                        ProductId = itemDto.ProductId,
                        InvoiceId = itemDto.InvoiceId,
                        ProductDiscountsId = itemDto.ProductDiscountsId,

                        Quantity = itemDto.Quantity,

                        Price = itemDto.Price,
                    
                        
                   
 
                    };
                  await  invoiceItemRepositry.AddInvoice(invoiceItem);
                     


                    var invoiceItemResponseDto = mapper.Map<InvoiceItem>(invoiceItem);
                    return invoiceItemResponseDto;
                }
        public async Task<IEnumerable<ProductDiscountSales>> GetProductSalesReportAsync(InvoiceItemFilter filter)
        {
            var allInvoiceItems = await invoiceItemRepositry.GetInvoiceItem(filter);

            var filteredInvoiceItems = allInvoiceItems
                .Where(item => (!filter.startDate.HasValue || item.CreatedAt >= filter.startDate) &&
                               (!filter.endDate.HasValue || item.CreatedAt <= filter.endDate))
                .ToList();

            var discountSales = mapper.Map<List<ProductDiscountSales>>(filteredInvoiceItems);

            return discountSales;
        }
        public async Task<List<MonthlyReportDiscount>> GetMonthlyReportDiscountAsync(InvoiceItemFilter filter)
        {
            var allInvoiceItems = await invoiceItemRepositry.GetInvoiceItem(filter);

            var filteredInvoiceItems = allInvoiceItems
                .Where(item => (!filter.startDate.HasValue || item.CreatedAt >= filter.startDate) &&
                               (!filter.endDate.HasValue || item.CreatedAt <= filter.endDate))
                .ToList();
             
            var discountReports = mapper.Map<List<MonthlyReportDiscount>>(filteredInvoiceItems);

            return discountReports;
        }
        public async Task<bool> DeleteInvoiceItemAsync(int id)
                {
                    var invoiceItem = await invoiceItemRepositry.GetInvoiceById(id);

                    if (invoiceItem == null)
                    {
                        return false;  
                    }

                    invoiceItemRepositry.DeleteInvoice(invoiceItem);
               

                    return true; 
                }

   
        public async Task<UpdateInvoiceItemResponseDto> GetInvoiceItemByIdAsync(int id)
            {
                var invoiceItem = await invoiceItemRepositry.GetInvoiceById(id);

                if (invoiceItem == null)
                {
                    return null; // Handle the not found scenario
                }

                return mapper.Map<UpdateInvoiceItemResponseDto>(invoiceItem);
            }
                public async Task<InvoiceItem> UpdateInvoiceItemAsync(int itemid,UpdateDtos itemDto)
                {
                    var existingItem = await invoiceItemRepositry.GetInvoiceById(itemid);

                    if (existingItem == null)
                    {
                        throw new ApplicationException($"InvoiceItem with ID {itemid} not found.");
                    }

                    existingItem.Quantity = itemDto.Quantity;
                    existingItem.Price = itemDto.Price;
               
                  

                    invoiceItemRepositry.UpdateInvoice(existingItem);
               

                    var invoiceItemResponseDto = mapper.Map<InvoiceItem>(existingItem);
                    return invoiceItemResponseDto;
                }

      
    }


}


