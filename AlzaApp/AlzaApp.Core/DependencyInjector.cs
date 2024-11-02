using AlzaApp.Core.Interfaces;
using AlzaApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaApp.Core;

public static class DependencyInjector
{
    public static IServiceCollection InjectCoreDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
        
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}