using MangoShopWorehouseService.Interface.ServiceInterface;
using MangoShopWorehouseService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MangoShopWorehouseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorehouseController : ControllerBase
    {
        private readonly IWorehouseService _worehouseService;

        public WorehouseController(IWorehouseService worehouseService)
        {
            _worehouseService = worehouseService;
        }

        // GET: api/Worehouse
        [HttpGet]
        public async Task<IActionResult> GetWorehouses()
        {
            var worehouses = await _worehouseService.GetWorehouses();
            return Ok(worehouses);
        }

        // GET: api/Worehouse/{id}
        [HttpGet("/product/{id}")]
        public async Task<IActionResult> GetWorehouseByProductId(int id)
        {
            var worehouse = await _worehouseService.GetWorehouseByProductId(id);
            if (worehouse == null)
            {
                return NotFound();
            }
            return Ok(worehouse);
        }

        // GET: api/Worehouse/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorehouseById(int id)
        {
            var worehouse = await _worehouseService.GetWorehouseById(id);
            if (worehouse == null)
            {
                return NotFound();
            }
            return Ok(worehouse);
        }

        // POST: api/Worehouse
        [HttpPost]
        public async Task<IActionResult> CreateWorehouse([FromBody] Worehouse worehouse)
        {
            if (worehouse == null)
            {
                return BadRequest("Invalid worehouse data.");
            }
            var addedWorehouse = await _worehouseService.AddWorehouse(worehouse);
            if (addedWorehouse == null)
            {
                return StatusCode(500, "Unable to create worehouse.");
            }
            return CreatedAtAction(nameof(GetWorehouseById), new { id = worehouse.ProductId }, worehouse);
        }

        // PUT: api/Worehouse/{id}/{quantity}
        [HttpPut("{id}/{productQuantity}")]
        public async Task<IActionResult> UpdateWorehouse(int id, int productQuantity)
        {
            var success = await _worehouseService.ChangeProductQuantity(id, productQuantity);
            if (!success)
            {
                return StatusCode(500, "Unable to update worehouse.");
            }

            return Ok();
        }

        // DELETE: api/Worehouse/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorehouseById(int id)
        {
            var success = await _worehouseService.DeleteWorehouseById(id);
            if (!success)
            {
                return StatusCode(500, "Unable to delete worehouse.");
            }
            return NoContent();
        }

        // DELETE: api/Worehouse/{id}
        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteWorehouseByProductId(int id)
        {
            var success = await _worehouseService.DeleteWorehouseByProductId(id);
            if (!success)
            {
                return StatusCode(500, "Unable to delete worehouse.");
            }
            return NoContent();
        }

        // GET: api/Worehouse/search?generalName=someName
        [HttpGet("search")]
        public async Task<IActionResult> GetWorehousesByGeneralName([FromQuery] string generalName)
        {
            var worehouses = await _worehouseService.GetWorehousesByGeneralNameOfProduct(generalName);
            if (worehouses == null || !worehouses.Any())
            {
                return NotFound();
            }
            return Ok(worehouses);
        }

        // POST: api/Worehouse/order
        [HttpPut("order")]
        public async Task<IActionResult> MakeOrder([FromQuery] int productId, [FromQuery] int quantity)
        {
            var success = await _worehouseService.MakeOrder(productId, quantity);
            if (!success)
            {
                return StatusCode(500, "Unable to place the order.");
            }
            return Ok("Order placed successfully.");
        }
    }
}
