using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipes.Response;

public sealed record GetRecipesResponse(List<RecipeDto> Recipes);