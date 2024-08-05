using AutoMapper;
using Invoice.Application.Invoice.InvoiceDto;
using Invoice.Domain.Entites;
using Invoice.Domain.Repositry;
using webs.Dtos;

namespace Invoice.Application.Invoice.Services
{
    public class InvoiceServices : IInvoiceService
    {
        private readonly IInvoiceRepositry _invoiceRepositry;
        private readonly IMapper _mapper;

        public InvoiceServices(IInvoiceRepositry invoiceRepositry, IMapper mapper)
        {
            _invoiceRepositry = invoiceRepositry;
            _mapper = mapper;
        }

        public async Task<InvoiceResponseDto> AddInvoiceAsync(CreateInvoiceDto createInvoiceDto)
        {
        
            var newInvoiceNumber = await GenerateNewInvoiceNumberAsync();
 
            var invoice = _mapper.Map<Invoices>(createInvoiceDto);

         
            invoice.InvoiceNumber = newInvoiceNumber;
         
    
            await _invoiceRepositry.AddInvoice(invoice);

         
            var createdInvoice = await _invoiceRepositry.GetInvoiceById(invoice.Id);

           
            var invoiceResponseDto = _mapper.Map<InvoiceResponseDto>(createdInvoice);

          
            return invoiceResponseDto;
        }
        public async Task<Invoices> GetInvoiceById(int invoiceId)
        {
            return await _invoiceRepositry.GetInvoiceById(invoiceId);
        }


 
 
        public async Task DeleteInvoiceAsync(int invoiceId)
        {
            await _invoiceRepositry.DeleteInvoice(invoiceId);
        }


 
        public decimal CalculateATotalAmount(Invoices invoices)
        {
            var invoiceAmount = invoices.InvoiceItems.Sum(i => i.Quantity * i.Price);

            return invoiceAmount;
        }

        public decimal CalculateTheTotalAmountOfDiscount(Invoices? invoices)
        {
            return (decimal)invoices.InvoiceItems.Sum(i => i.Quantity * i.Price * (i.ProductDiscounts.DiscountValue ) / 100);
        }

    
        public async Task<List<Invoices>> GetInvoiceByDate(DateTime? StartDate, DateTime? EndDate)
        {
            return await _invoiceRepositry.GetInvoiceByDate(StartDate, EndDate);

        }
        public decimal CalculateTheNetAmount(Invoices invoices)
        {
            return CalculateATotalAmount(invoices) - CalculateTheTotalAmountOfDiscount(invoices);
        }
        public async Task<object> GetMonthlyProfitReport(DateTime? startDate , DateTime? EndDate)
        {
            var invoices = await GetInvoiceByDate(startDate, EndDate);
            var totalProfit = invoices.Sum(i => CalculateTheNetAmount(i));
            var totalDiscount = invoices.SelectMany(i => i.InvoiceItems)
                              .Sum(item => item.ProductDiscounts.DiscountValue);
            var netAmount = totalProfit - totalDiscount;

            return new { startDate,EndDate, TotalProfit = totalProfit, TotalDiscount = totalDiscount, NetAmount = netAmount };
        }
        public async Task<object> GetProductReport(DateTime startDate, DateTime endDate, List<int> productIds)
        {
            var invoices = await GetInvoiceByDate(startDate, endDate);
            var filteredInvoiceItems = invoices
               .Where(item => item.CreatedAt >= startDate && item.Updated <= endDate)
               .ToList();
            var productReport = filteredInvoiceItems
                .SelectMany(i => i.InvoiceItems)
                .Where(ii => productIds.Contains(ii.ProductId))
                .GroupBy(ii => ii.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    ProductName = g.First().Product.Name,
                    TotalSales = g.Sum(ii => ii.Quantity * ii.Price),
                    TotalDiscount = g.Sum(ii => ii.ProductDiscounts.DiscountValue.GetValueOrDefault()),
                    DiscountCount = g.Count(ii => ii.ProductDiscounts.DiscountValue.HasValue),
                    DiscountDetails = g.Where(ii => ii.ProductDiscounts.DiscountValue.HasValue)
                                       .Select(ii => new { ii.ProductDiscounts.DiscountValue, ii.Quantity, ii.Price })
                });

            var response = new
            {
                StartDate = startDate,
                EndDate = endDate,
                ProductIds = productIds,
                ProductReport = productReport
            };

            return response;
        }


        private async Task<string> GenerateNewInvoiceNumberAsync()
        {
            var lastInvoice = (await _invoiceRepositry.GetInvoiceByDate(DateTime.MinValue, DateTime.MaxValue))
                .OrderByDescending(i => i.CreatedAt)
                .FirstOrDefault();

            string newInvoiceNumber;
            if (lastInvoice == null)
            {
                newInvoiceNumber = "INV-0001";
            }
            else
            {
                var lastNumber = int.Parse(lastInvoice.InvoiceNumber.Split('-')[1]);
                newInvoiceNumber = $"INV-{(lastNumber + 1).ToString("D4")}";
            }

            return newInvoiceNumber;
        }



        public async Task<UpdateInvoiceResponseDto> UpdateInvoiceAsync( updateInvoiceDto updateInvoiceDto, int invoiceId)
        {
            var existingInvoice = await _invoiceRepositry.GetInvoiceById(invoiceId);

            if (existingInvoice == null)
            {
                throw new ApplicationException($"Invoice with ID {invoiceId} not found.");
            }

       
            existingInvoice.CustomerName = updateInvoiceDto. CustomerName;
      

            _invoiceRepositry.UpdateInvoice(existingInvoice);
         
       


            var invoiceResponseDto = _mapper.Map<UpdateInvoiceResponseDto>(updateInvoiceDto);

            return invoiceResponseDto;
        }

   
    }
}