using MediatR;
using MSRP.Application.DTOs.RecipeDto;
using MSRP.Application.Queries.Recipes.GetRecipes.Response;

namespace MSRP.Application.Queries.Recipes.GetRecipes.Query;

public sealed record GetRecipesQuery() : IRequest<List<RecipeDto>>, IRequest<GetRecipesResponse>;