using MediatR;
using MSRP.Application.Features.Recipes.Queries.GetFavoriteRecipes.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetFavoriteRecipes.Query;

public sealed record GetFavoriteRecipesQuery() : IRequest<GetFavouriteRecipesResponse>;