using MediatR;
using MSRP.Application.DTOs.RecipeDto;

namespace MSRP.Application.Queries.Recipes.GetFavoriteRecipes;

public sealed record GetFavoriteRecipesQuery() : IRequest<List<RecipeDto>?>;