using MangoShopOrderServcie.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MangoShopOrderServcie
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
    }
}
