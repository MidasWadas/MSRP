using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByDietary.Response;

public sealed record GetRecipesByDietaryResponse(List<RecipeDto>? Recipes);