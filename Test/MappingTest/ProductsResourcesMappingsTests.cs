using DigitalMarket_API.Domain.Entities;
using Xunit;
using ProductResources = DigitalMarket_API.Domain.Service.Resource.ProductResources;
using Mapster;

namespace DigitalMarket_API.Test.MappingTest
{
    public class ProductsResourcesMappingsTests
    {
        private readonly ServiceProvider serviceProvider;

        public ProductsResourcesMappingsTests()
        {
            var services = new ServiceCollection();
            var assembly = typeof(ProductsResourcesMappingsTests).Assembly;
            services.RegisterMapsterConfiguration();

            serviceProvider = services.BuildServiceProvider();
        }


        [Fact]
        public void Map_from_Product_to_ProductDto()
        {
            var productEntity = new Product
            {
                Id = 1,
                Name = "Arroz",
                Category = new Category { Name = "Comida", Products = new List<Product>() },
                Price = 200,
                Discount = 0,
                Unit = UnitOfMeasurement.Gram,
                QuantityInStock = 100
            };
            productEntity.Category.Products.Add(productEntity);

            var productDto = productEntity.Adapt<ProductResources::ProductDto>();
            Assert.Equal("Comida", productDto.Category.Name);
            Assert.Equal("G", productDto.Unit);
        }


        [Fact]
        public void Map_from_CreateProduct_to_Product()
        {
            var categoryName = "Comida";
            var createProduct = new ProductResources::CreateProduct("Arroz", 200, 0, 100, "G", new ProductResources::CategoryDto(0, categoryName));
            var product = createProduct.Adapt<Product>();

            Assert.NotNull(product);
            Assert.Equal(UnitOfMeasurement.Gram, product.Unit);
            Assert.NotNull(product.Category);
            Assert.Equal(categoryName, product.Category.Name);
        }

        [Fact]
        public void Map_from_UpdateProduct_to_Product()
        {
            var categoryName = "Comida";
            var updateProduct = new ProductResources::UpdateProduct(1, "Arroz", 200, 0, 100, "G", new ProductResources::CategoryDto(1, categoryName));
            var product = updateProduct.Adapt<Product>();

            Assert.NotNull(product);
            Assert.Equal(UnitOfMeasurement.Gram, product.Unit);
            Assert.NotNull(product.Category);
            Assert.Equal(categoryName, product.Category.Name);
        }
    }
}
