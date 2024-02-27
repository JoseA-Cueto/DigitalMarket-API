namespace DigitalMarket_API.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int QuantityInStock { get; set; } // Cantidad disponible para vender
        public UnitOfMeasurement Unit { get; set; } // Unidad de medida (KG, Litro, etc)

        public required Category Category { get; set; }
    }
}
