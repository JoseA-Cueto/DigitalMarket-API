using DigitalMarket_API.Domain.Service.Resource.CategoryResources;
using DigitalMarket_API.Domain.Service;

namespace DigitalMarket_API.Service
{
    public class CategoriesService : ICategoriesService
    {
        public Task<CategoryDto> CreateAsync(CreateCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<Error?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CategoryDto, Error>> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CategoryDto, Error>> UpdateAsync(UpdateCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
