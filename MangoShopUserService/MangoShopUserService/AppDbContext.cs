﻿using MangoShopUserService.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoShopUserService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
