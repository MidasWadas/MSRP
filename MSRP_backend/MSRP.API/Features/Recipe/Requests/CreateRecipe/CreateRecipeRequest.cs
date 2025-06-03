using System.ComponentModel.DataAnnotations;

namespace MSRP.API.Features.Recipe.Requests.CreateRecipe;

public sealed record CreateRecipeRequest
(
    [Required] string Title,
    [Required] string Description,
    [Required] string ImageUrl,
    [Required] int PrepTime,
    [Required] int CookTime,
    [Required] int Servings,
    [Required] int DifficultyId,
    [Required] int CuisineId,
    [Required] int MealTypeId,
    [Required] List<int> DietariesIds,
    [Required] List<string> Ingredients,
    [Required] List<string> Instructions,
    int CreatedByUserId
);