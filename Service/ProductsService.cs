using DigitalMarket_API.Domain.Entities;
using DigitalMarket_API.Domain.Repositories;
using DigitalMarket_API.Domain.Service.Resource.ProductResources;
using DigitalMarket_API.Domain.Service;
using Mapster;

namespace DigitalMarket_API.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository repository;

        public ProductsService(IProductsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProductDto> CreateAsync(CreateProduct createProduct)
        {
            var product = createProduct.Adapt<Product>();
            await repository.AddAsync(product);
            return product.Adapt<ProductDto>();
        }

        public async Task<Error?> DeleteAsync(int id)
        {
            var existingProduct = await repository.GetOne(id);
            if (existingProduct is null)
            {
                return new Error(ErrorReason.NotFound, "The product to delete does not exist :(");
            }

            await repository.Delete(id);
            return null; // No error
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await repository.GetAll();
            return products.Adapt<List<ProductDto>>();
        }

        public async Task<OneOf<ProductDto, Error>> GetOneAsync(int id)
        {
            var product = await repository.GetOne(id);
            if (product is null)
                return new Error(ErrorReason.NotFound, $"There is not product whit ID: {id}");
            return product.Adapt<ProductDto>();
        }

        public async Task<OneOf<ProductDto, Error>> UpdateAsync(UpdateProduct updateProduct)
        {
            var existingProduct = await repository.GetOne(updateProduct.Id);
            if (existingProduct is null)
                return new Error(ErrorReason.NotFound, $"There is not product whit ID: {updateProduct.Id}");

            existingProduct.Name = updateProduct.Name;
            existingProduct.Price = updateProduct.Price;
            existingProduct.Discount = updateProduct.Discount;
            existingProduct.QuantityInStock = updateProduct.QuantityInStock;
            existingProduct.Unit = UnitOfMeasurements.FromString(updateProduct.Unit);
            existingProduct.Category = updateProduct.Category.Adapt<Category>();

            return existingProduct.Adapt<ProductDto>();
        }
    }
}
