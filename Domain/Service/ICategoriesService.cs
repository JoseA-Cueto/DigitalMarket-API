
using DigitalMarket_API.Domain.Service.Resource.CategoryResources;

namespace DigitalMarket_API.Domain.Service
{
    public interface ICategoriesService
    {
        Task<CategoryDto> CreateAsync(CreateCategory category);
        Task<OneOf<CategoryDto, Error>> UpdateAsync(UpdateCategory category);
        Task<Error?> DeleteAsync(int id);
        Task<OneOf<CategoryDto, Error>> GetOneAsync(int id);
        Task<List<CategoryDto>> GetAllAsync();
    }
}
