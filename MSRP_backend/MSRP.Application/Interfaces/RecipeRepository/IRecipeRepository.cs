using MSRP.Domain.Entities.Recipe;

namespace MSRP.Application.Interfaces.RecipeRepository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken);
    Task<Recipe?> GetRecipeByIdAsync(int id, CancellationToken cancellationToken);
    Task<Recipe> CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<Recipe> UpdateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetFavoriteRecipesAsync(CancellationToken cancellationToken);
}