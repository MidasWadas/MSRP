using MediatR;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByDietary.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByDietary.Query;

public sealed record GetRecipesByDietaryQuery(int DietaryId) : IRequest<GetRecipesByDietaryResponse>;