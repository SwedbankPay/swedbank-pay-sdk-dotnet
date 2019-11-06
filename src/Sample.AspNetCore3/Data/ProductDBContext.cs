using Microsoft.EntityFrameworkCore;
using Sample.AspNetCore3.Models;

namespace Sample.AspNetCore3.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}