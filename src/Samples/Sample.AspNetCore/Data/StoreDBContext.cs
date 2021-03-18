using Microsoft.EntityFrameworkCore;

using Sample.AspNetCore.Models;

namespace Sample.AspNetCore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}