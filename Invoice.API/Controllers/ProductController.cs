using Invoice.Application.Invoice.InvoiceDto;
using Invoice.Application.Product.ProductDto;
using Invoice.Application.Product.Services;
using Invoice.Domain.Filter;
using Microsoft.AspNetCore.Mvc;

namespace TaskInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
            
        }
 
        [HttpGet]
        public async Task<ActionResult<List<CreatedProductResponse>>> GetProducts([FromQuery]ProductFilter filter)
        {
            var products = await _productService.GetAllProductsAsync(filter);
            return Ok(products);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDtos>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product);
        }

        
        [HttpPost]
        public async Task<ActionResult<ProductDtos>> CreateProduct( ProductDtos productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
         
            var createdProduct = await  _productService.AddProductAsync(productDto);
            return Ok(createdProduct);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDtos>> UpdateProduct(int id, ProductDtos productDto)
        {
           
            if (id != id)
            {
                return BadRequest();
            }
            var result = await _productService.UpdateProductAsync(id, productDto);

          

            return Ok(result);  
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound(); 
            }

            return NoContent();  
        }
    }
}


