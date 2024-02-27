using DigitalMarket_API.Domain.Repositories;
using DigitalMarket_API.Domain.Service;
using DigitalMarket_API.Service;
using DigitalMarket_API.Test.Services_test.RepositoriMock;

namespace DigitalMarket_API.Test.Services_test
{
    public class ServiceTestsBase
    {
        protected readonly ServiceProvider serviceProvider;

        public ServiceTestsBase()
        {
            var services = new ServiceCollection();
            var assembly = typeof(ProductsServiceTests).Assembly;
            services.RegisterMapsterConfiguration();
            services.AddServices();
            services.AddRepositories();
            serviceProvider = services.BuildServiceProvider();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepositoryMock>();
            services.AddScoped<ICategoriesRepository, CategoriesRepositoryMock>();
        }
    }
}
