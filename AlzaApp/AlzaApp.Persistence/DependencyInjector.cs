using AlzaApp.Domain.Interfaces;
using AlzaApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaApp.Persistence;

public static class DependencyInjector
{
    public static IServiceCollection InjectPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
        });

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IProductsRepository, ProductsRepository>();

        return services;
    }
}