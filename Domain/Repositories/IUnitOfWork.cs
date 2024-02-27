namespace DigitalMarket_API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IProductsRepository Products { get; }
        ICategoriesRepository Categories { get; }
        Task SaveAsync();
    }
}
