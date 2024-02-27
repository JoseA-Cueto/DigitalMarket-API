using DigitalMarket_API.Context;
using DigitalMarket_API.Domain.Entities;
using DigitalMarket_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket_API.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private MarketDbContext _context;

        public CategoriesRepository(MarketDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity) => await _context.AddAsync(entity);

        public async Task<Category> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Remove(category!);
            return category!;
        }

        public Task<List<Category>> GetAll() => _context.Categories.ToListAsync();

        public Task<Category> GetOne(int id) => _context.Categories.FindAsync(id).AsTask()!;

        public Task GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
