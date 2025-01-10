using BLL.MangoShopProductService.Service;
using BLL.MangoShopProductService.BlModel;
using Microsoft.AspNetCore.Mvc;
using MangoShopProductService.ModelDto.ApiRequest;
using MangoShopProductService.ModelDto.ApiResponse;
using AutoMapper;
using DAL.MangoShopProductService.Model;
using Newtonsoft.Json;
using System.Text;

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productBl = _mapper.Map<ProductBl>(product);

            await _productService.AddProductAsync(productBl);

            product.Id = productBl.Id;

            var warehouseStatusCode = await CreateWorehouseProductRequest(product);
            if (!warehouseStatusCode)
            {
                return Problem("500 error");
            }


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

        private async Task<bool> CreateWorehouseProductRequest(ProductApiRequest product)
        {
            var worehouse = _mapper.Map<WorehouseApiRequest>(product);

            var url = "https://localhost:7000/gateway/warehouse";

            var json = JsonConvert.SerializeObject(worehouse);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                //TODO: Check If the  service is avalible
                //TODO: Create logic for Post and Put
                //TODO: Update model and add worehouse ID??? 

                var response = await client.PostAsync(url, content);

                var responseContent = await response.Content.ReadAsStringAsync();
                if(responseContent == StatusCode(500, "Unable to create worehouse.").ToString())
                {
                    return false;
                }
                return true;
            }
        }
    }
}
