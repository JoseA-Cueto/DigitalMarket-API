using DigitalMarket_API.Domain.Entities;
using Mapster;
using ProductResources = DigitalMarket_API.Domain.Service.Resource.ProductResources;

namespace DigitalMarket_API
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<ProductResources::CreateProduct, Product>
                .NewConfig()
                .Map(product => product.Unit, createProduct => UnitOfMeasurements.FromString(createProduct.Unit));

            TypeAdapterConfig<ProductResources::UpdateProduct, Product>
                .NewConfig()
                .Map(product => product.Unit, updateProduct => UnitOfMeasurements.FromString(updateProduct.Unit));

            TypeAdapterConfig<Product, ProductResources::ProductDto>
                .NewConfig()
                .Map(productDto => productDto.Unit, product => product.Unit.AsString());

            TypeAdapterConfig<ProductResources::CategoryDto, Category>
                .NewConfig()
                .Map(category => category.Products, _ => new List<Product>());
        }
    }

}
