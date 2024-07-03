using AwesomeShop.Services.Products.Application.Mappers;
using AwesomeShop.Services.Products.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Services.Products.Application;

public static class Extension
{
    
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllProducts).Assembly));
        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddSingleton<IProductMapper, ProductMapper>();
        return services;
    }

}