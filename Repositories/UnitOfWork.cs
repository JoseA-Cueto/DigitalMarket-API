using DigitalMarket_API.Context;
using DigitalMarket_API.Domain.Repositories;

namespace DigitalMarket_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductsRepository Products { get; }

        public ICategoriesRepository Categories { get; }

        private MarketDbContext _context;

        public UnitOfWork(IProductsRepository products, ICategoriesRepository categories, MarketDbContext context)
        {
            Products = products;
            Categories = categories;
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
