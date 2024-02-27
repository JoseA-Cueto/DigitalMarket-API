namespace DigitalMarket_API.Domain.Service.Resource.ProductResources
{
    public record struct CreateProduct(
      string Name,
      decimal Price,
      decimal Discount,
      int QuantityInStock,
      string Unit,
      CategoryDto Category
  );

    public record struct UpdateProduct(
        int Id,
        string Name,
        decimal Price,
        decimal Discount,
        int QuantityInStock,
        string Unit,
        CategoryDto Category
    );

    public record struct ProductDto(
        int Id,
        string Name,
        decimal Price,
        decimal Discount,
        int QuantityInStock,
        string Unit,
        CategoryDto Category
    );

    public record struct CategoryDto(int Id, string Name);
}
