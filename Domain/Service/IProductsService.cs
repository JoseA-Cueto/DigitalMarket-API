

using DigitalMarket_API.Domain.Service.Resource.ProductResources;

namespace DigitalMarket_API.Domain.Service
{
    public interface IProductsService
    {
        Task<ProductDto> CreateAsync(CreateProduct category);
        Task<OneOf<ProductDto, Error>> UpdateAsync(UpdateProduct category);
        Task<Error?> DeleteAsync(int id);
        Task<OneOf<ProductDto, Error>> GetOneAsync(int id);
        Task<List<ProductDto>> GetAllAsync();
    }
}
