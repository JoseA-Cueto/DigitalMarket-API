namespace DigitalMarket_API.Domain.Service.Resource.CategoryResources
{
    public record CreateCategory(string Name);

    public record UpdateCategory(int Id, string Name);

    public record CategoryDto(int Id, string Name, List<ProductDto> Products);

    public record ProductDto(int Id, string Name);
}
