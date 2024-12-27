using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            bool useOnlyInMemoryDatabase = false;
            if (useOnlyInMemoryDatabase)
            {
                services.AddDbContext<CatalogContext>(c =>
                   c.UseInMemoryDatabase("Catalog"));
            }
            else
            {
                services.AddDbContext<CatalogContext>((sp, c) =>
                    c.UseSqlServer(
                        configuration.GetConnectionString("DDDCatalog"),
                        x => x.MigrationsAssembly("Infrastructure"))
                    .AddInterceptors(sp.GetServices<ISaveChangesInterceptor>()));
            }
            services.AddSingleton(TimeProvider.System);
            return services;
        }
    }
}
