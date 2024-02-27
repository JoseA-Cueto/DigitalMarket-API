using DigitalMarket_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket_API.Context
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {
        }

        public required DbSet<Product> Products { get; set; }
        public required DbSet<Category> Categories { get; set; }
    }
}
