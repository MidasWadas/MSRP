using Microsoft.EntityFrameworkCore;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Domain.Recipe;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories
{
    public class RecipesRepository(ApiContext context) : IRecipesRepository
    {
        public async Task<List<RecipeDto>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            // return await context.Recipes
            //     .AsNoTracking()
            //     .Include(r => r.CuisineId)
            //     .ToListAsync(cancellationToken);
            return null;
        }

        public async Task<RecipeDto?> GetRecipeByIdAsync(int id, CancellationToken cancellationToken)
        {
            // return await context.Recipes
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
            return null;
        }

        public async Task<Recipe> CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            context.Recipes.Add(recipe);
            return await context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => recipe, cancellationToken);
        }

        public async Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe, CancellationToken cancellationToken)
        {
            if (!await context.Recipes.AnyAsync(r => r.Id == id, cancellationToken)) 
                throw new KeyNotFoundException($"Recipe with ID {id} not found");

            context.Recipes.Update(recipe);
            await context.SaveChangesAsync(cancellationToken);
            return recipe;
        }
        
        public async Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken)
        {
            var recipe = await context.Recipes.FindAsync([id], cancellationToken);
            if (recipe == null)
                return false;

            context.Recipes.Remove(recipe);
            return await context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => true, cancellationToken);
        }

        public async Task<List<RecipeDto>> GetRecipesByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken)
        {
            // return await context.Recipes
            //     .Where(r => r.CuisineId == cuisineId)
            //     .AsNoTracking()
            //     .ToListAsync(cancellationToken);
            return null;
        }

        public async Task<List<RecipeDto>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken)
        {
            // return await context.Recipes
            //     .Where(r => r.MealTypeId == mealTypeId)
            //     .AsNoTracking()
            //     .ToListAsync(cancellationToken);
            return null;
        }

        public async Task<List<RecipeDto>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken)
        {
            // return await context.Recipes
            //     .Where(r => r.DietariesIds.Contains(dietaryId))
            //     .AsNoTracking()
            //     .ToListAsync(cancellationToken);
            return null;
        }
    }
}