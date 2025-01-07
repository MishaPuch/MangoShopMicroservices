using MangoShopBasketService.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoShopBasketService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Basket> Baskets { get; set; }
    }
}
