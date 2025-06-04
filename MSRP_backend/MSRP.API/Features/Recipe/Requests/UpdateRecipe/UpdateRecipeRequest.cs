using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Features.Recipe.Requests.UpdateRecipe;

public sealed record UpdateRecipeRequest(
    [Required] int Id,
    string Title,
    string Description,
    string ImageUrl,
    int PrepTime,
    int CookTime,
    int Servings,
    int DifficultyId,
    int CuisineId,
    int MealTypeId,
    List<int> DietariesIds,
    List<string> Ingredients,
    List<string> Instruction,
    int UpdatedByUserId
);
