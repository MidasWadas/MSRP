using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByMealType.Response;

public sealed record GetRecipesByMealTypeResponse(List<RecipeDto>? Recipes);