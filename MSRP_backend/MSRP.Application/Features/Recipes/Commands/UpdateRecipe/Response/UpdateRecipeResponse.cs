using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Commands.UpdateRecipe.Response;

public sealed record UpdateRecipeResponse(RecipeDto? RecipeDto);