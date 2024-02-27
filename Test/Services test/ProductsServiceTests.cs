using DigitalMarket_API.Domain.Repositories;
using DigitalMarket_API.Domain.Service.Resource.ProductResources;
using DigitalMarket_API.Domain.Service;
using DigitalMarket_API.Test.Services_test.RepositoriMock;
using System.Diagnostics;
using Xunit;

namespace DigitalMarket_API.Test.Services_test
{
    public class ProductsServiceTests : ServiceTestsBase
    {
        private readonly IProductsService productsService;
        private readonly ProductsRepositoryMock productsRepository;

        public ProductsServiceTests()
        {
            this.productsService = serviceProvider.GetRequiredService<IProductsService>();
            this.productsRepository = serviceProvider.GetRequiredService<IProductsRepository>() as ProductsRepositoryMock
                ?? throw new UnreachableException("ProductsRepositoryMock should not be null. It must be injected in the DI container");
        }

        [Fact]
        public async Task Add_Product()
        {
            var product = new CreateProduct("Arroz", 200, 0, 100, "G", new CategoryDto(0, "Comida"));
            await productsService.CreateAsync(product);

            Assert.Equal(1, productsRepository.Entities.Count);
        }

        [Fact]
        public async Task Update_Product()
        {
            var createProductDto = new CreateProduct("Arroz", 200, 0, 100, "G", new CategoryDto(0, "Comida"));
            await productsService.CreateAsync(createProductDto);

            var updateProductDto = new UpdateProduct(0, "Café", 300, 100, 0, "U", new CategoryDto(0, "Bebida"));
            await productsService.UpdateAsync(updateProductDto);

            var productEntity = productsRepository.Entities[0];
            Assert.Equal(0, productEntity.Id);
            Assert.Equal("Café", productEntity.Name);
            Assert.Equal("Bebida", productEntity.Category.Name);
        }

        [Fact]
        public async Task Get_Product_by_Id()
        {
            await productsService.CreateAsync(new CreateProduct("Arroz", 200, 0, 100, "G", new CategoryDto(0, "Comida")));
            await productsService.CreateAsync(new CreateProduct("Café", 300, 0, 100, "U", new CategoryDto(0, "Bebida")));
            await productsService.CreateAsync(new CreateProduct("Pullover Azul", 500, 0, 100, "U", new CategoryDto(0, "Ropa")));

            var idToObtain = 1;
            var result = await productsService.GetOneAsync(idToObtain);
            var productDto = result.Match(
                p => p,
                err => (ProductDto?)null
            );
            Assert.NotNull(productDto);
            Assert.Equal(1, productDto?.Id);
            Assert.Equal("Café", productDto?.Name);
            Assert.Equal("Bebida", productDto?.Category.Name);
        }
    }

}
