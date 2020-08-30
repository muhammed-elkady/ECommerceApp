using ECommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }
        
        public DbSet<Product> Products { get; set; }

    }
}