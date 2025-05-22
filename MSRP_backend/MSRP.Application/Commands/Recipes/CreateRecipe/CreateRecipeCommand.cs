using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Commands.Recipes.CreateRecipe;

public sealed record CreateRecipeCommand(
    string Title,
    string Description,
    string ImageUrl,
    int PrepTime,
    int CookTime,
    int Servings,
    CreateRecipeCommand_RecipeDifficulty RecipeDifficulty,
    CreateRecipeCommand_RecipeCuisineType RecipeCuisineType,
    CreateRecipeCommand_RecipeMealType RecipeMealType,
    List<CreateRecipeCommand_RecipeDietaryOption> Dietaries,
    List<string> Ingredients,
    List<string> Instructions,
    bool IsFavorite
) : IRequest<RecipeDto>;

public sealed record CreateRecipeCommand_RecipeDifficulty(int Id, string Name);
public sealed record CreateRecipeCommand_RecipeCuisineType(int Id, string Name);
public sealed record CreateRecipeCommand_RecipeMealType(int Id, string Name);
public sealed record CreateRecipeCommand_RecipeDietaryOption(int Id, string Name);
