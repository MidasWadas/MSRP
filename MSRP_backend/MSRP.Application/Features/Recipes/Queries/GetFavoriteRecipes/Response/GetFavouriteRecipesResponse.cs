using MSRP.Application.Features.Recipes.DTO;

namespace MSRP.Application.Features.Recipes.Queries.GetFavoriteRecipes.Response;

public sealed record GetFavouriteRecipesResponse(List<RecipeDto>? Recipes);
