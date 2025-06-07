using Microsoft.EntityFrameworkCore;
using MSRP.Application.Features.Recipes.DTO;
using MSRP.Application.Features.Recipes.Interface;
using MSRP.Domain.Recipe;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories
{
    public class RecipesRepository(ApiContext context) : IRecipesRepository
    {
        public async Task<List<RecipeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await context.Recipes
                .AsNoTracking()
                .Join(context.Difficulties,
                    recipe => recipe.DifficultyId,
                    difficulty => difficulty.Id,
                    (recipe, difficulty) => new { recipe, difficulty })
                .Join(context.Cuisines,
                    rd => rd.recipe.CuisineId,
                    cuisine => cuisine.Id,
                    (rd, cuisine) => new { rd.recipe, rd.difficulty, cuisine })
                .Join(context.MealTypes,
                    rdc => rdc.recipe.MealTypeId,
                    mealType => mealType.Id,
                    (rdc, mealType) => new { rdc.recipe, rdc.difficulty, rdc.cuisine, mealType })
                .Select(x => new RecipeDto(
                    x.recipe.Id,
                    x.recipe.Title,
                    x.recipe.Description,
                    x.recipe.ImageUrl,
                    x.recipe.PrepTime,
                    x.recipe.CookTime,
                    x.recipe.Servings,
                    new RecipeDifficultyDto(x.difficulty.Id, x.difficulty.Name),
                    new RecipeCuisineTypeDto(x.cuisine.Id, x.cuisine.Name),
                    new RecipeMealTypeDto(x.mealType.Id, x.mealType.Name),
                    context.Dietaries
                        .Where(d => x.recipe.DietariesIds.Contains(d.Id))
                        .Select(d => new RecipeDietaryOptionDto(d.Id, d.Name))
                        .ToList(),
                    x.recipe.Ingredients,
                    x.recipe.Instructions,
                    x.recipe.CreatedByUserId
                ))
                .ToListAsync(cancellationToken);
        }

        public async Task<RecipeDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Recipes
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Join(context.Difficulties,
                    recipe => recipe.DifficultyId,
                    difficulty => difficulty.Id,
                    (recipe, difficulty) => new { recipe, difficulty })
                .Join(context.Cuisines,
                    rd => rd.recipe.CuisineId,
                    cuisine => cuisine.Id,
                    (rd, cuisine) => new { rd.recipe, rd.difficulty, cuisine })
                .Join(context.MealTypes,
                    rdc => rdc.recipe.MealTypeId,
                    mealType => mealType.Id,
                    (rdc, mealType) => new { rdc.recipe, rdc.difficulty, rdc.cuisine, mealType })
                .Select(x => new RecipeDto(
                    x.recipe.Id,
                    x.recipe.Title,
                    x.recipe.Description,
                    x.recipe.ImageUrl,
                    x.recipe.PrepTime,
                    x.recipe.CookTime,
                    x.recipe.Servings,
                    new RecipeDifficultyDto(x.difficulty.Id, x.difficulty.Name),
                    new RecipeCuisineTypeDto(x.cuisine.Id, x.cuisine.Name),
                    new RecipeMealTypeDto(x.mealType.Id, x.mealType.Name),
                    context.Dietaries
                        .Where(d => x.recipe.DietariesIds.Contains(d.Id))
                        .Select(d => new RecipeDietaryOptionDto(d.Id, d.Name))
                        .ToList(),
                    x.recipe.Ingredients,
                    x.recipe.Instructions,
                    x.recipe.CreatedByUserId
                ))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> CreateAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            context.Recipes.Add(recipe);
            await context.SaveChangesAsync(cancellationToken);
            return recipe.Id;
        }

        public async Task<int> UpdateAsync(int id, Recipe recipe, CancellationToken cancellationToken)
        {
            if (!await context.Recipes.AnyAsync(r => r.Id == id, cancellationToken)) 
                throw new KeyNotFoundException($"Recipe with ID {id} not found");

            context.Recipes.Update(recipe);
            await context.SaveChangesAsync(cancellationToken);
            return recipe.Id;
        }
        
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var recipe = await context.Recipes.FindAsync([id], cancellationToken);
            if (recipe == null)
                return false;

            context.Recipes.Remove(recipe);
            return await context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => true, cancellationToken);
        }

        public async Task<List<RecipeDto>> GetByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken)
        {
            return await context.Recipes
                .AsNoTracking()
                .Where(r => r.CuisineId == cuisineId)
                .Join(context.Difficulties,
                    recipe => recipe.DifficultyId,
                    difficulty => difficulty.Id,
                    (recipe, difficulty) => new { recipe, difficulty })
                .Join(context.Cuisines,
                    rd => rd.recipe.CuisineId,
                    cuisine => cuisine.Id,
                    (rd, cuisine) => new { rd.recipe, rd.difficulty, cuisine })
                .Join(context.MealTypes,
                    rdc => rdc.recipe.MealTypeId,
                    mealType => mealType.Id,
                    (rdc, mealType) => new { rdc.recipe, rdc.difficulty, rdc.cuisine, mealType })
                .Select(x => new RecipeDto(
                    x.recipe.Id,
                    x.recipe.Title,
                    x.recipe.Description,
                    x.recipe.ImageUrl,
                    x.recipe.PrepTime,
                    x.recipe.CookTime,
                    x.recipe.Servings,
                    new RecipeDifficultyDto(x.difficulty.Id, x.difficulty.Name),
                    new RecipeCuisineTypeDto(x.cuisine.Id, x.cuisine.Name),
                    new RecipeMealTypeDto(x.mealType.Id, x.mealType.Name),
                    context.Dietaries
                        .Where(d => x.recipe.DietariesIds.Contains(d.Id))
                        .Select(d => new RecipeDietaryOptionDto(d.Id, d.Name))
                        .ToList(),
                    x.recipe.Ingredients,
                    x.recipe.Instructions,
                    x.recipe.CreatedByUserId
                ))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<RecipeDto>> GetByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken)
        {
            return await context.Recipes
                .AsNoTracking()
                .Where(r => r.MealTypeId == mealTypeId)
                .Join(context.Difficulties,
                    recipe => recipe.DifficultyId,
                    difficulty => difficulty.Id,
                    (recipe, difficulty) => new { recipe, difficulty })
                .Join(context.Cuisines,
                    rd => rd.recipe.CuisineId,
                    cuisine => cuisine.Id,
                    (rd, cuisine) => new { rd.recipe, rd.difficulty, cuisine })
                .Join(context.MealTypes,
                    rdc => rdc.recipe.MealTypeId,
                    mealType => mealType.Id,
                    (rdc, mealType) => new { rdc.recipe, rdc.difficulty, rdc.cuisine, mealType })
                .Select(x => new RecipeDto(
                    x.recipe.Id,
                    x.recipe.Title,
                    x.recipe.Description,
                    x.recipe.ImageUrl,
                    x.recipe.PrepTime,
                    x.recipe.CookTime,
                    x.recipe.Servings,
                    new RecipeDifficultyDto(x.difficulty.Id, x.difficulty.Name),
                    new RecipeCuisineTypeDto(x.cuisine.Id, x.cuisine.Name),
                    new RecipeMealTypeDto(x.mealType.Id, x.mealType.Name),
                    context.Dietaries
                        .Where(d => x.recipe.DietariesIds.Contains(d.Id))
                        .Select(d => new RecipeDietaryOptionDto(d.Id, d.Name))
                        .ToList(),
                    x.recipe.Ingredients,
                    x.recipe.Instructions,
                    x.recipe.CreatedByUserId
                ))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<RecipeDto>> GetByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken)
        {
            return await context.Recipes
                .AsNoTracking()
                .Where(r => r.DietariesIds.Contains(dietaryId))
                .Join(context.Difficulties,
                    recipe => recipe.DifficultyId,
                    difficulty => difficulty.Id,
                    (recipe, difficulty) => new { recipe, difficulty })
                .Join(context.Cuisines,
                    rd => rd.recipe.CuisineId,
                    cuisine => cuisine.Id,
                    (rd, cuisine) => new { rd.recipe, rd.difficulty, cuisine })
                .Join(context.MealTypes,
                    rdc => rdc.recipe.MealTypeId,
                    mealType => mealType.Id,
                    (rdc, mealType) => new { rdc.recipe, rdc.difficulty, rdc.cuisine, mealType })
                .Select(x => new RecipeDto(
                    x.recipe.Id,
                    x.recipe.Title,
                    x.recipe.Description,
                    x.recipe.ImageUrl,
                    x.recipe.PrepTime,
                    x.recipe.CookTime,
                    x.recipe.Servings,
                    new RecipeDifficultyDto(x.difficulty.Id, x.difficulty.Name),
                    new RecipeCuisineTypeDto(x.cuisine.Id, x.cuisine.Name),
                    new RecipeMealTypeDto(x.mealType.Id, x.mealType.Name),
                    context.Dietaries
                        .Where(d => x.recipe.DietariesIds.Contains(d.Id))
                        .Select(d => new RecipeDietaryOptionDto(d.Id, d.Name))
                        .ToList(),
                    x.recipe.Ingredients,
                    x.recipe.Instructions,
                    x.recipe.CreatedByUserId
                ))
                .ToListAsync(cancellationToken);
        }
    }
}