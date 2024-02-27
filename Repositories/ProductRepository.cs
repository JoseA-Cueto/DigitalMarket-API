using DigitalMarket_API.Context;
using DigitalMarket_API.Domain.Entities;
using DigitalMarket_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket_API.Repositories
{
    public class ProductRepository : IProductsRepository
    {

        private MarketDbContext _context;

        public ProductRepository(MarketDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product entity) => await _context.AddAsync(entity);


        public async Task<Product> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Remove(product!);
            return product!;
        }

        public Task<List<Product>> GetAll() => _context.Products.ToListAsync();

        public Task<Product> GetOne(int id) => _context.Products.FindAsync(id).AsTask()!;


        public Task UpdateAsync(Product entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
