using MediatR;
using MSRP.Application.Features.Recipes.Queries.GetRecipesByMealType.Response;

namespace MSRP.Application.Features.Recipes.Queries.GetRecipesByMealType.Query;

public sealed record GetRecipesByMealTypeQuery(int MealTypeId) : IRequest<GetRecipesByMealTypeResponse>;