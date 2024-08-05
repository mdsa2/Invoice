using Invoice.Application.Invoice.InvoiceDto;
using Invoice.Application.Invoice.Services;
 
using Invoice.Domain.Repositry;
using Microsoft.AspNetCore.Mvc;


namespace TaskInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private readonly IInvoiceService _invoicesServices;
        public InvoicesController(IInvoiceService invoicesServices)
        {
            _invoicesServices = invoicesServices;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceDto createInvoiceDto)

        {

            var result = await _invoicesServices.AddInvoiceAsync(createInvoiceDto);
            return Ok(result);
 
        }
     [HttpDelete]
        [Route("remove-invoice")]
        public async Task<IActionResult> DeleteInvoice([FromQuery] int invoiceId)
        {
            await _invoicesServices.DeleteInvoiceAsync(invoiceId);
            return Ok();
        }
     
      

        [HttpGet]
        [Route("monthly-profit-report")]
        public async Task<IActionResult> MonthlyProfitReport([FromQuery] DateTime? StartDate,DateTime? EndDate)
        {
            var report = await _invoicesServices.GetMonthlyProfitReport(StartDate,EndDate);
            return Ok(report);

        }

        [HttpGet]
        [Route("GetInvoiceById")]
        public async Task<IActionResult> GetInvoiceById(int Id)
        {
            var Invoiceid = await _invoicesServices.GetInvoiceById(Id);
            return Ok(Invoiceid);

        }


        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] updateInvoiceDto request)
        {
            try
            {
                var invoiceResponseDto = await _invoicesServices.UpdateInvoiceAsync(request, id);
                return Ok(invoiceResponseDto);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }


}