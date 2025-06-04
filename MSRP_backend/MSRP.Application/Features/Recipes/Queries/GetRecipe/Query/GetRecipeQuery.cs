using MediatR;
using MSRP.Application.Features.Recipes.Queries.GetRecipe.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipe.Query;

public sealed record GetRecipeQuery(int Id) : IRequest<GetRecipeResponse>;