using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;   // make sure this namespace contains Menu, Vendor, Order

namespace WebApplication1.Models
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> opts) : base(opts) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Wallet> Wallets => Set<Wallet>();

        // NEW – fully-typed sets so EF can track the tables
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<Vendor> Vendors => Set<Vendor>();
        public DbSet<Order> Orders => Set<Order>();   // optional, but needed for /Orders
    }
}
