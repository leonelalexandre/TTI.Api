using TTI.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace TTI.Infra.Ioc.DependencyInjection
{
    public static class ConfigureBindingsMapper
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileMapping));
        }
    }
}
