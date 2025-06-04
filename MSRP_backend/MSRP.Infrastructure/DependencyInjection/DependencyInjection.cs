using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Infrastructure.Persistence;
using MSRP.Infrastructure.Repositories;

namespace MSRP.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Konfiguracja DbContext dla PostgreSQL
        services.AddDbContext<ApiContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        // Rejestracja repozytorium
        services.AddScoped<IRecipesRepository, RecipesRepository>();
        
        return services;
    }
}