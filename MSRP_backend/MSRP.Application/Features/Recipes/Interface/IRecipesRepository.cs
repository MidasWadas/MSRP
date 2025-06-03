using MSRP.Application.Features.Recipes.DTO;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Features.Recipes.Interface;

public interface IRecipesRepository
{
    Task<List<RecipeDto>> GetRecipesAsync(CancellationToken cancellationToken);
    Task<RecipeDto?> GetRecipeByIdAsync(int id, CancellationToken cancellationToken);
    Task<Recipe> CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe, CancellationToken cancellationToken);
    Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken);
    Task<List<RecipeDto>> GetRecipesByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken);
    Task<List<RecipeDto>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken);
    Task<List<RecipeDto>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken);
}