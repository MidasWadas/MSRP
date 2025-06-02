using MSRP.Application.DTOs.RecipeDto;
using MSRP.Domain.Entities.Recipe;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Interfaces.RecipeRepository;

public interface IRecipeRepository
{
    Task<List<Recipe>> GetRecipesAsync(CancellationToken cancellationToken);
    Task<Recipe?> GetRecipeByIdAsync(int id, CancellationToken cancellationToken);
    Task<Recipe> CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe, CancellationToken cancellationToken);
    Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken);
}