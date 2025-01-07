using MangoShopBasketService.Model;
using MangoShopBasketService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoShopBasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketService _basketService;

        public BasketController(BasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasketByUserId(int userId)
        {
            var baskets = await _basketService.GetBasketByUserIdAsync(userId);
            if (baskets == null || baskets.Count == 0)
            {
                return NotFound($"No baskets found for user with ID {userId}.");
            }
            return Ok(baskets);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] Basket basket)
        {
            if (basket == null)
            {
                return BadRequest("Basket cannot be null.");
            }

            await _basketService.AddBasket(basket);
            return CreatedAtAction(nameof(GetBasketByUserId), new { userId = basket.UserId }, basket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var basket = await _basketService.GetBasketByUserIdAsync(id);
            if (basket == null)
            {
                return NotFound($"Basket with ID {id} not found.");
            }

            await _basketService.DeleteBasketByIdAsync(id);
            return NoContent();
        }
    }
}
