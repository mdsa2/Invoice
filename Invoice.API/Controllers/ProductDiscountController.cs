using Invoice.Application.Product.ProductDto;
using Invoice.Application.ProductDiscount.ProductDiscountDtos;
using Invoice.Application.ProductDiscount.ProductDiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace TaskInvoice.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductDiscountController : Controller
    {
        private readonly IProductDiscountsServices _productDiscountsServices;
        public ProductDiscountController(IProductDiscountsServices productDiscountsServices)
        {
            _productDiscountsServices = productDiscountsServices;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductDiscountDto>>> GetAllProductDiscounts()
        {
            var productDiscounts = await _productDiscountsServices.GetAllProductsAsync();
            return Ok(productDiscounts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDiscountDto>> GetProductDiscountById(int id)
        {
            var ProductDiscountId = await _productDiscountsServices.GetProductByIdAsync(id);
            if (ProductDiscountId == null)
            {
                return NotFound();
            }
            return Ok(ProductDiscountId);
        }


        [HttpPost]
        public async Task<ActionResult<CreateProductDiscountRepsonse>> CreateProductDiscount(ProductDiscountDto productDiscountDto)
        {
          
            var createdDiscounts = await _productDiscountsServices.AddProductAsync( productDiscountDto);
       
            return Ok(createdDiscounts);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateProductDiscountRepsonse>> updateProductDiscount(int id,UpdateProductDiscountRepsonse productDiscountDto)
        {
            if (id != id) {
            BadRequest();
            }
            var result = await _productDiscountsServices.UpdateProductDiscountAsync(id, productDiscountDto);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteProductDiscount(int id)
        {
      
            var result = await _productDiscountsServices.DeleteProductDiscountAsync(id);

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
