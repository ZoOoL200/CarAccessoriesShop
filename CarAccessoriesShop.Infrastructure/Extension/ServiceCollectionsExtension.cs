using CarAccessoriesShop.Application.Presistences.Contracts.Repos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Infrastructure.Repositories;
using CarAccessoriesShop.Infrastucture.Persistence;
using CarAccessoriesShop.Infrastucture.Seeders;
using CarAccessoriesShop.Infrastucture.UnitofWorkPattren;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAccessoriesShop.Infrastucture.Extension;

public static class ServiceCollectionsExtension
{
    public static void AddMarketInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        // Register your DbContext with the dependency injection container
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("localConnection")));

        // Add the Unit of Work and Lazy Resolver
        services.AddScoped<IUnitofWork, UnitofWork>();
        services.AddScoped(typeof(Lazy<>), typeof(LazyResolver<>));

        // 
        services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));

        // Register other services, repositories, etc.
        services.AddScoped<ICountryKeySeeder, CountryKeySeeder>();
    }
}
