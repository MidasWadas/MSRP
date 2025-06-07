using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Interfaces.Mapper;
using MSRP.Infrastructure.Mapper;
using MSRP.Infrastructure.Persistence;
using MSRP.Infrastructure.Repositories;

namespace MSRP.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IRecipesRepository, RecipesRepository>();

        services.AddScoped<IEntityMapper, EntityMapper>();
        
        return services;
    }
}