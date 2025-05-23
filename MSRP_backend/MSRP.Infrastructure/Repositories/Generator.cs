using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.Generator;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories;

public class Generator(ApiContext context) : IGenerator
{
    public async Task<int> GenerateNextRecipeIdAsync(CancellationToken cancellationToken)
    {
        if (!context.Recepies.Any())
            return 1;
        
        var maxId = await context.Recepies.MaxAsync(r => r.Id, cancellationToken);
        return maxId + 1;
    }
    
    public async Task<int> GenerateNextCuisineOptionIdAsync(CancellationToken cancellationToken)
    {
        if (!context.CuisineOptions.Any())
            return 1;
        
        var maxId = await context.CuisineOptions.MaxAsync(c => c.Id, cancellationToken);
        return maxId + 1;
    }
    
    public async Task<int> GenerateNextMealTypeIdAsync(CancellationToken cancellationToken)
    {
        if (!context.MealTypes.Any())
            return 1;
        
        var maxId = await context.MealTypes.MaxAsync(m => m.Id, cancellationToken);
        return maxId + 1;
    }
    
    public async Task<int> GenerateNextDietaryOptionIdAsync(CancellationToken cancellationToken)
    {
        if (!context.DietaryOptions.Any())
            return 1;
        
        var maxId = await context.DietaryOptions.MaxAsync(d => d.Id, cancellationToken);
        return maxId + 1;
    }
    
    public async Task<int> GenerateNextDifficultyOptionIdAsync(CancellationToken cancellationToken)
    {
        if (!context.DifficultyOptions.Any())
            return 1;
        
        var maxId = await context.DifficultyOptions.MaxAsync(rd => rd.Id, cancellationToken);
        return maxId + 1;
    }
    
    
}