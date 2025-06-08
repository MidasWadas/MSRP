using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Application.Features.Recipes.Queries.GetRecipe.Query;
using MSRP.Application.Interfaces.Generator;
using MSRP.Application.Interfaces.Mapper;
using MSRP.Application.Interfaces.Repository;
using MSRP.Infrastructure.Mapper;
using MSRP.Infrastructure.Persistence;
using MSRP.Infrastructure.Repositories;

namespace MSRP.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetRecipeQueryHandler).Assembly);
        });
        
        services.AddDbContext<ApiContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddTransient<IGenerator, Generator>();
        
        services.AddScoped<IRecipesRepository, RecipesRepository>();
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

        services.AddScoped<IEntityMapper, EntityMapper>();
        
        return services;
    }
}