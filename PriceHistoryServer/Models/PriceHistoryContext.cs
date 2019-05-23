using Microsoft.EntityFrameworkCore;

namespace PriceHistoryServer.Models
{
    public class PriceHistoryContext : DbContext
    {
        public PriceHistoryContext(DbContextOptions<PriceHistoryContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPurchase> ProductPurchases { get; set; }
    }
}
