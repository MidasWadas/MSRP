using MediatR;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByCuisine.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByCuisine.Query;

public sealed record GetRecipesByCuisineQuery(int CuisineId) : IRequest<GetRecipesByCuisineResponse>;