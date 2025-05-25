using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Commands.Recipes.UpdateRecipe;

public sealed record UpdateRecipeCommand(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    int PrepTime,
    int CookTime,
    int Servings,
    int RecipeDifficultyId,
    int RecipeCuisineId,
    int RecipeMealTypeId,
    List<int> DietariesIds,
    List<string> Ingredients,
    List<string> Instructions,
    int UpdatedByUserId
    ) : IRequest<RecipeDto>;