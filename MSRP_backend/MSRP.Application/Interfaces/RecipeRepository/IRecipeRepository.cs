using MSRP.Domain.Entities.Recipe;

namespace MSRP.Application.Interfaces.RecipeRepository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetRecipesAsync(CancellationToken cancellationToken);
    Task<Recipe?> GetRecipeByIdAsync(int id, CancellationToken cancellationToken);
    //instead of taking Recipe I need to create new object that will contain all the properties to create Recipe
    Task<Recipe> CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<Recipe> UpdateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<bool> DeleteRecipeAsync(int id, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetRecipesByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken);
    Task<List<Recipe>> GetFavoriteRecipesAsync(CancellationToken cancellationToken);
}