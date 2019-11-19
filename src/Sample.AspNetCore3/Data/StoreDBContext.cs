namespace Sample.AspNetCore3.Data
{
    using Microsoft.EntityFrameworkCore;
    using Sample.AspNetCore3.Models;

    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}