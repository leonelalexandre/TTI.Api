using TTI.Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using TTI.Application.Services;

namespace TTI.Infra.Ioc.DependencyInjection
{
    public static class ConfigureBindingsService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
