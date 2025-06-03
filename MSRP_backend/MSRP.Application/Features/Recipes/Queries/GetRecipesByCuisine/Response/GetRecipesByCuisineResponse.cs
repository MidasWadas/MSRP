using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByCuisine.Response;

public sealed record GetRecipesByCuisineResponse(List<RecipeDto>? Recipes);