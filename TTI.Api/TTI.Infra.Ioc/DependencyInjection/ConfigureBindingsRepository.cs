using Microsoft.Extensions.DependencyInjection;
using TTI.Domain.Interface;
using TTI.Infra.Data.Repository;

namespace TTI.Infra.Ioc.DependencyInjection
{
    public static class ConfigureBindingsRepository
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
