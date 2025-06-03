using MediatR;
using MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Response;

namespace MSRP.Application.Features.MealTypes.Queries.GetMealTypes.Query;

public sealed record GetMealTypesQuery() : IRequest<GetMealTypesResponse>;