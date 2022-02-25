using Microsoft.EntityFrameworkCore;
using PRE.Pagination.API.Application.Services;
using PRE.Pagination.API.Data;

namespace PRE.Pagination.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        // Usando com banco de dados em memória
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("CatalogDB"));

        services.AddScoped<IProductService, ProductService>();

        services.AddTransient<ProductPopulateService>();

        return services;
    }
}
