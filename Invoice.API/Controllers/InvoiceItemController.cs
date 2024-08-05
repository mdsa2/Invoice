using Invoice.Application.InvoiceItems.InvoiceItemDto;
using Invoice.Application.InvoiceItems.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : Controller
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemController(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        [HttpPost]
        [Route("AddItemInvoice")]
        public async Task<ActionResult<MonthlyReportDiscount>> AddInvoiceItem([FromBody] InvoiceItemDtos itemDto)
        {
            var result = await _invoiceItemService.AddInvoiceItemAsync(itemDto);
            if (result == null)
            {
                return BadRequest("Could not create invoice item.");
            }

            // Manually create the location URI
            var locationUri = Url.Action(nameof(GetInvoiceItemById), new { id = result.Id });
            return Created(locationUri, result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyReportDiscount>> GetInvoiceItemById(int id)
        {
            var result = await _invoiceItemService.GetInvoiceItemByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("monthly-discount-report")]
        public async Task<IActionResult> GetMonthlyDiscountReport([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var report = await _invoiceItemService.GetMonthlyReportDiscountAsync(startDate, endDate);
            return Ok(report);
        }
        [HttpGet("Product-Sales")]
        public async Task<IActionResult> GetProductSales([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var report = await _invoiceItemService.GetProductSalesReportAsync(startDate, endDate);
            return Ok(report);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<MonthlyReportDiscount>> UpdateInvoiceItem(int id, [FromBody] UpdateDtos itemDto)
        {
            if (id != id)
            {
                return BadRequest();
            }

            var result = await _invoiceItemService.UpdateInvoiceItemAsync(id, itemDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceItem(int id)
        {
            var result = await _invoiceItemService.DeleteInvoiceItemAsync(id);

            if (result)
            {
                return Ok("Deleted successfully");
            }
            else
            {
                return NotFound();
            }
        }
    }
}