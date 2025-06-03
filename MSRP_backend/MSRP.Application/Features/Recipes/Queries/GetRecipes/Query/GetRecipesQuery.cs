using MediatR;
using MSRP.Application.Features.Recipes.Queries.GetRecipes.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipes.Query;

public sealed record GetRecipesQuery() : IRequest<GetRecipesResponse>;