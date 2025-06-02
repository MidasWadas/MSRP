using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.RecipeRepository;
using MSRP.Domain.Recipe;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories
{
    public class RecipeRepository(ApiContext context) : IRecipeRepository
    {
        public async Task<List<Recipe>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            return await context.Recepies
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Recepies
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<Recipe> CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            context.Recepies.Add(recipe);
            return await context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => recipe, cancellationToken);
        }

        public async Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe, CancellationToken cancellationToken)
        {
            if (!await context.Recepies.AnyAsync(r => r.Id == id, cancellationToken)) 
                throw new KeyNotFoundException($"Recipe with ID {id} not found");

            context.Recepies.Update(recipe);
            await context.SaveChangesAsync(cancellationToken);
            return recipe;
        }
        
        public async Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken)
        {
            var recipe = await context.Recepies.FindAsync([id], cancellationToken);
            if (recipe == null)
                return false;

            context.Recepies.Remove(recipe);
            return await context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => true, cancellationToken);
        }

        public async Task<List<Recipe>> GetRecipesByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken)
        {
            return await context.Recepies
                .Where(r => r.CuisineId == cuisineId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Recipe>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken)
        {
            return await context.Recepies
                .Where(r => r.MealTypeId == mealTypeId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Recipe>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken)
        {
            return await context.Recepies
                .Where(r => r.DietariesIds.Contains(dietaryId))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}