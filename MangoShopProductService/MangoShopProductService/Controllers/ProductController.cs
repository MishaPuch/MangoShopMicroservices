using BLL.MangoShopProductService.Service;
using BLL.MangoShopProductService.BlModel;
using Microsoft.AspNetCore.Mvc;
using MangoShopProductService.ModelDto.ApiRequest;
using MangoShopProductService.ModelDto.ApiResponse;
using AutoMapper;
using DAL.MangoShopProductService.Model;

namespace MangoShopProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var productsBl = await _productService.GetAllProductsAsync();
            var products = _mapper.Map<List<ProductApiResponse>>(productsBl);

            return Ok(products);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productBl = await _productService.GetProductByIdAsync(id);
            var product = _mapper.Map<ProductApiResponse>(productBl);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost("product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductApiRequest product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var productBl = _mapper.Map<ProductBl>(product);
            await _productService.AddProductAsync(productBl);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductApiRequest product)
        {
            if (!ModelState.IsValid || id != product.Id) return BadRequest();
            var productBl = _mapper.Map<ProductBl>(product);
            await _productService.UpdateProductAsync(productBl);

            return NoContent();
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);

            return NoContent();
        }
    }
}
