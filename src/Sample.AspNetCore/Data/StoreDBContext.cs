namespace Sample.AspNetCore.Data
{
    using Microsoft.EntityFrameworkCore;
    using Sample.AspNetCore.Models;

    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}