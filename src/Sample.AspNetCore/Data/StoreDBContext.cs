namespace Sample.AspNetCore3.Data
{
    using Microsoft.EntityFrameworkCore;
    using Sample.AspNetCore3.Models;

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