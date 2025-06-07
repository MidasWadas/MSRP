using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Commands.CreateRecipe.Response;

public sealed record CreateRecipeResponse(RecipeDto? RecipeDto);