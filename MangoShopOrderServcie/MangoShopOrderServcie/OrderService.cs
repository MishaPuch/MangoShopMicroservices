using MangoShopOrderServcie.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoShopOrderServcie
{
    public class OrderService
    {
        private readonly AppDbContext _appDbContext;
        public OrderService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> GetOrderByUserIdAsync(int userId)
        {
            return await _appDbContext.Orders.FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _appDbContext.Orders.ToListAsync();
        }

        public async Task UpdateOrders(Order order)
        {
            _appDbContext.Orders.Update(order);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task AddOrder(Order basket)
        {
            await _appDbContext.Orders.AddAsync(basket);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            var basket = await _appDbContext.Orders.FindAsync(id);
            _appDbContext.Orders.Remove(basket);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
