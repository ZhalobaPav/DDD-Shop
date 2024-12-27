using Infrastructure.Data;

namespace API.Extensions
{
    public static class ConfigureServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            return services;
        }
    }
}
