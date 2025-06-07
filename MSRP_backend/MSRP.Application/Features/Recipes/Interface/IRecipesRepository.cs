using MSRP.Application.Features.Recipes.DTO;
using MSRP.Domain.Recipe;

namespace MSRP.Application.Features.Recipes.Interface;

public interface IRecipesRepository
{
    Task<List<RecipeDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<RecipeDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(Recipe recipe, CancellationToken cancellationToken);
    Task<int> UpdateAsync(int id, Recipe recipe, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<List<RecipeDto>> GetByCuisineIdAsync(int cuisineId, CancellationToken cancellationToken);
    Task<List<RecipeDto>> GetByMealTypeIdAsync(int mealTypeId, CancellationToken cancellationToken);
    Task<List<RecipeDto>> GetByDietaryIdAsync(int dietaryId, CancellationToken cancellationToken);
}