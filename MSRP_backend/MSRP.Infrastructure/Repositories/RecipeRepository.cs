using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.RecipeRepository;
using MSRP.Domain.Entities.Recipe;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories
{
    public class RecipeRepository(ApiContext context) : IRecipeRepository
    {
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(CancellationToken cancellationToken)
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

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            context.Recepies.Update(recipe);
            return await context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => recipe, cancellationToken);
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
                .Where(r => r.CuisineType.Id == cuisineId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Recipe>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken)
        {
            return await context.Recepies
                .Where(r => r.MealType.Id == mealTypeId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Recipe>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken)
        {
            return await context.Recepies
                .Where(r => r.Dietaries.Any(d => d.Id == dietaryId))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Recipe>> GetFavoriteRecipesAsync(CancellationToken cancellationToken)
        {
            return await context.Recepies
                .Where(r => r.IsFavorite)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}