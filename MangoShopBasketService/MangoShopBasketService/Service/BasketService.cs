using MangoShopBasketService.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoShopBasketService.Service
{
    public class BasketService
    {
        private readonly AppDbContext _appDbContext;
        public BasketService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Basket>> GetBasketByUserIdAsync(int userId)
        {
            var basket = await _appDbContext.Baskets.Where(x => x.UserId == userId).ToListAsync();
            return basket;
        }
        public async Task AddBasket(Basket basket)
        {
            await _appDbContext.Baskets.AddAsync(basket);
            await _appDbContext.SaveChangesAsync();
        } 
        public async Task DeleteBasketByIdAsync(int id)
        {
            var basket = await _appDbContext.Baskets.FindAsync(id);
            _appDbContext.Baskets.Remove(basket);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
