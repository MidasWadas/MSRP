using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipe.Response;

public sealed record GetRecipeResponse(RecipeDto? Recipe);