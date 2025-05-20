using MSRP.Domain.Entities.Recipe;

namespace MSRP.Application.Interfaces.RecipeRepository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllRecipesAsync();
    Task<Recipe?> GetRecipeByIdAsync(int id);
}